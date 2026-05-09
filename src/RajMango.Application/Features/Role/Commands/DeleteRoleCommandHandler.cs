using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteRoleCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<Role>().FindAsync(command.Id);
                if (user != null)
                {
                    _dataContext.Get<Role>().Remove(user);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "Role is Deleted");
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
