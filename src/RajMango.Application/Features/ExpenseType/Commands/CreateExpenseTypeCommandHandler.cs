using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    internal class CreateExpenseTypeCommandHandler : IRequestHandler<CreateExpenseTypeCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateExpenseTypeCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateExpenseTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                command.CreatedAt = Clock.Now();
                var mappedEntity = _mapper.Map<ExpenseType>(command);
                _dataContext.Get<ExpenseType>().Add(mappedEntity);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(mappedEntity.Id, "ExpenseType is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"ExpenseType Creation Failed");
        }
    }
}
