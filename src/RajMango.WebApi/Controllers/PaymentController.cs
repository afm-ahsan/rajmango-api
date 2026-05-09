using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RajMango.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllPaymentDto>>>> Get()
        {
            return await _mediator.Send(new GetAllPaymentQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetPaymentByIdDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetPaymentByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<GetPaymentCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetPaymentCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetPaymentWithPaginationDto>>> GetPaymentWithPagination([FromQuery] GetPaymentWithPaginationQuery query)
        {
            var validator = new GetPaymentWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        //[HttpGet]
        //[Route("GetPagedAndSortedResult")]
        //public async Task<IEnumerable<PaymentInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<PaymentInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreatePaymentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdatePaymentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeletePaymentCommand { Id = id });
        }
    }
}