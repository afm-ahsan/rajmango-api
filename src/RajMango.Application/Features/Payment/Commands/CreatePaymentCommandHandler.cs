using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    internal class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                command.CreatedAt = Clock.Now();
                var mappedEntity = _mapper.Map<Payment>(command);
                _dataContext.Get<Payment>().Add(mappedEntity);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(mappedEntity.Id, "Payment is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Payment Creation Failed");
        }
    }
}
