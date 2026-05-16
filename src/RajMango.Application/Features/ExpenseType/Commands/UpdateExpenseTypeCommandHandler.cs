using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateExpenseTypeCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateExpenseTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<ExpenseType>().FindAsync(command.Id);
                if (user != null)
                {
                    var mappedEntity = _mapper.Map<ExpenseType>(command);
                    
                    _dataContext.Get<ExpenseType>().Update(mappedEntity);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "ExpenseType is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"ExpenseType information not found with the Id - {command.Id}");
        }
    }
}
