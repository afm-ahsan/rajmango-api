using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateCourierProviderCommandHandler : IRequestHandler<CreateCourierProviderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateCourierProviderCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCourierProviderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierProvider = new CourierProvider
                {
                    Name = command.Name,
                    Description = command.Description,
                    SupportPhone = command.SupportPhone,
                    Email = command.Email,
                    IsActive = command.IsActive,
                };

                _dataContext.Get<CourierProvider>().Add(courierProvider);

                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(courierProvider.Id, "Courier Provider is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier Provider Creation Failed.");
        }
    }
}
