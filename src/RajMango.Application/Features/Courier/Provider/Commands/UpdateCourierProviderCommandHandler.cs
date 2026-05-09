using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdateCourierProviderCommandHandler : IRequestHandler<UpdateCourierProviderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateCourierProviderCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateCourierProviderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierProvider = await _dataContext.Get<CourierProvider>().FindAsync(command.Id);
                if (courierProvider != null)
                {
                    courierProvider.Name = command.Name;
                    courierProvider.Description = command.Description;
                    courierProvider.SupportPhone = command.SupportPhone;
                    courierProvider.Email = command.Email;
                    courierProvider.IsActive = command.IsActive;

                    _dataContext.Get<CourierProvider>().Update(courierProvider);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(courierProvider.Id, "Courier Provider is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier provider information not found with the Id - {command.Id}");
        }
    }
}
