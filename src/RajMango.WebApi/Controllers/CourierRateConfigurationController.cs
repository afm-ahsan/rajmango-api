using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs.Courier.RateConfig;
using RajMango.Application.Features.Courier.RateConfig.Commands;
using RajMango.Application.Features.Courier.RateConfig.Queries;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/courier-rate-config")]
    public class CourierRateConfigurationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourierRateConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.CourierRateConfigurations.View)]
        public async Task<ActionResult<Result<CourierRateConfigurationDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetCourierRateConfigByIdQuery(id));
        }

        [HttpGet("by-provider/{courierProviderId}/active")]
        [RequirePermission(Permissions.CourierRateConfigurations.View)]
        public async Task<ActionResult<Result<List<CourierRateConfigurationDto>>>> GetActiveByProvider(int courierProviderId)
        {
            return await _mediator.Send(new GetActiveCourierRatesByProviderQuery(courierProviderId));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.CourierRateConfigurations.View)]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierRateConfigCountQuery());
        }

        [HttpGet("paged")]
        [RequirePermission(Permissions.CourierRateConfigurations.View)]
        public async Task<ActionResult<PaginatedResult<CourierRateConfigurationDto>>> GetPaged(
            [FromQuery] GetCourierRateConfigWithPaginationQuery query)
        {
            var validator = new GetCourierRateConfigWithPaginationValidator();
            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            return await _mediator.Send(query);
        }

        [HttpPost]
        [RequirePermission(Permissions.CourierRateConfigurations.Create)]
        public async Task<ActionResult<Result<int>>> Create([FromBody] CreateCourierRateConfigCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.CourierRateConfigurations.Update)]
        public async Task<ActionResult<Result<int>>> Update(int id, [FromBody] UpdateCourierRateConfigCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.CourierRateConfigurations.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteCourierRateConfigCommand { Id = id });
        }
    }
}
