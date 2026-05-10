using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces;
using RajMango.DataAccess.Extensions;
using RajMango.Infrastructure.Extensions;
using RajMango.Shared;
using RajMango.WebApi.Hubs;
using RajMango.WebApi.OpenApi;
using RajMango.WebApi.Services;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Register IHttpContextAccessor
//builder.Services.AddHttpContextAccessor();

// Ensure Logs directory exists
Directory.CreateDirectory("Logs");
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

// Add DbContext
//builder.Services.AddDbContext<DataContext>(options =>
//        options.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.Parse("10.4.19-mariadb")),
//        ServiceLifetime.Scoped);
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IRealtimeService, RealtimeService>();
builder.Services.AddSingleton<IUserIdProvider, RajMangoUserIdProvider>();
builder.Services.AddHttpContextAccessor();

// Add API Services
builder.Services.RegisterApiServices();
// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(configuration);
builder.Services.AddDataAccessLayer(configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure OpenApi Security Scheme
builder
    .Services
    .Configure<AppSettings>(configuration)
    .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
    .AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value)
    .AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
#pragma warning disable CS8604 // Possible null reference argument.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Security:Jwt:ClientSecret"])),
            ValidIssuer = configuration["Security:Jwt:Authority"],
            ValidAudience = configuration["Security:Jwt:Audience"]
        };
#pragma warning restore CS8604 // Possible null reference argument.

        configuration.Bind($"{nameof(AppSettings.Security)}:{nameof(AppSettings.Security.Jwt)}", options);
    })
    .Services
    .AddHttpClient()
    .AddSwaggerGen();

builder.Services.AddSignalR();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app
    .UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint(configuration["Swagger:Endpoint"], configuration["Swagger:Version"]);
        setup.EnableTryItOutByDefault();
        setup.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
    });
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseStaticFiles(); // serves wwwroot — /uploads/... paths are public from here

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<RajMangoHub>("/hubs/rajmango");

app.Run();


//var host = new WebHostBuilder()
//            .UseKestrel()
//            .UseContentRoot(Directory.GetCurrentDirectory())
//            .UseIISIntegration()
//            .UseStartup()
//            .Build();

//host.Run();
