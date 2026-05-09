using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RajMango.Application.Features.Commands
{
    internal class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
        {
            try
            {
                command.CreatedAt = Clock.Now();
                var mappedEntity = _mapper.Map<Expense>(command);
                _dataContext.Get<Expense>().Add(mappedEntity);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(mappedEntity.Id, "Expense is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Expense Creation Failed");
        }
    }
}
