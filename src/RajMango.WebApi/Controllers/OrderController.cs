using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<OrderDto>>>> Get()
        {
            return await _mediator.Send(new GetAllOrderQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<OrderDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetOrderByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetOrderCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<OrderDto>>> GetCategoryWithPagination([FromQuery] GetOrderWithPaginationQuery query)
        {
            var validator = new GetOrderWithPaginationValidator();

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
        //public async Task<IEnumerable<CategoryInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<CategoryInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateOrderCommand command)
        {
            var validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.Orders.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var validator = new UpdateOrderCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            return await _mediator.Send(command);
        }

        [HttpPatch("{id}/status")]
        [RequirePermission(Permissions.Orders.Update)]
        public async Task<ActionResult<Result<int>>> UpdateStatus(int id, [FromBody] UpdateOrderStatusCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.Orders.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteOrderCommand { Id = id });
        }
    }
}