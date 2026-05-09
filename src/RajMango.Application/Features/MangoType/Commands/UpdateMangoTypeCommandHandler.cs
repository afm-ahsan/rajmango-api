using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateMangoTypeCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateMangoTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<MangoType>().FindAsync(command.Id);
                if (user != null)
                {
                    command.UpdatedAt = Clock.Now();

                    var mappedEntity = _mapper.Map<MangoType>(command);
                    
                    _dataContext.Get<MangoType>().Update(mappedEntity);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "Mango type is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Mango type is not found with the Id - {command.Id}");
        }
    }
}
