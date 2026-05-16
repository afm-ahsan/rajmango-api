using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateExpenseCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateExpenseCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<Expense>().FindAsync(command.Id);
                if (user != null)
                {
                    var mappedEntity = _mapper.Map<Expense>(command);
                    
                    _dataContext.Get<Expense>().Update(mappedEntity);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "Expense is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Expense information not found with the Id - {command.Id}");
        }
    }
}
