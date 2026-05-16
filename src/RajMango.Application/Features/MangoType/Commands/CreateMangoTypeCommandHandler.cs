using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateMangoTypeCommandHandler : IRequestHandler<CreateMangoTypeCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateMangoTypeCommandHandler(IErrorHandler errorHandler,
                                             IDataContext dataContext,
                                             IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateMangoTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var mappedEntity = _mapper.Map<MangoType>(command);
                _dataContext.Get<MangoType>().Add(mappedEntity);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(mappedEntity.Id, "Mango Type is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Mango Type Creation Failed");
        }
    }
}
