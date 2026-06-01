using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdateMangoTypeCommandHandler : IRequestHandler<UpdateMangoTypeCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public UpdateMangoTypeCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(UpdateMangoTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _dataContext.Get<MangoType>()
                    .FindAsync(new object[] { command.Id }, cancellationToken);

                if (entity == null)
                    return await Result<int>.FailureAsync($"Mango type not found with Id {command.Id}.");

                entity.Name           = command.Name;
                entity.Description    = command.Description;
                entity.ImagePath      = command.ImagePath;
                entity.Region         = command.Region;
                entity.AverageWeight  = command.AverageWeight;
                entity.MangoGrade     = command.MangoGrade;
                entity.SweetnessLevel = command.SweetnessLevel;
                entity.Sequence       = command.Sequence;
                entity.UpdatedBy      = command.UpdatedBy ?? 0;
                entity.UpdatedAt      = DateTime.UtcNow;

                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(entity.Id, "Mango type updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Mango type update failed for Id {command.Id}.");
        }
    }
}
