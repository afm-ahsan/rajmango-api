using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Newtonsoft.Json;

namespace RajMango.Application.Features.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<Role>().FindAsync(command.Id);
                if (user != null)
                {
                    command.UpdatedAt = Clock.Now();

                    command.PermissionJson = JsonConvert.SerializeObject(command.Permissions);

                    var mappedEntity = _mapper.Map<Role>(command);
                    
                    _dataContext.Get<Role>().Update(mappedEntity);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "Role is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Role information not found with the Id - {command.Id}");
        }
    }
}
