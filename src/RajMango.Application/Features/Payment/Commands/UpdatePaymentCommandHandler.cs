using AutoMapper;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdatePaymentCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<Payment>().FindAsync(command.Id);
                if (user != null)
                {
                    command.UpdatedAt = Clock.Now();

                    var mappedEntity = _mapper.Map<Payment>(command);
                    
                    _dataContext.Get<Payment>().Update(mappedEntity);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "Payment is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Payment information not found with the Id - {command.Id}");
        }
    }
}
