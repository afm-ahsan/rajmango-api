using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/admin/orders")]
    public class AdminOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Paged order list with rich filters for admin management.</summary>
        [HttpGet]
        [RequirePermission(Permissions.Orders.AdminView)]
        public async Task<ActionResult<PaginatedResult<AdminOrderListDto>>> GetPaged([FromQuery] GetAdminOrderListQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>Full order details including customer, courier, items, and payment history.</summary>
        [HttpGet("{id}")]
        [RequirePermission(Permissions.Orders.AdminView)]
        public async Task<ActionResult<Result<AdminOrderDetailsDto>>> GetDetails(int id)
        {
            return await _mediator.Send(new GetAdminOrderDetailsQuery(id));
        }

        /// <summary>Confirm a pending order.</summary>
        [HttpPost("{id}/confirm")]
        [RequirePermission(Permissions.Orders.AdminManage)]
        public async Task<ActionResult<Result<int>>> Confirm(int id)
        {
            return await _mediator.Send(new UpdateOrderStatusCommand { Id = id, NewStatus = OrderStatus.Confirmed });
        }

        /// <summary>Move a confirmed order to processing.</summary>
        [HttpPost("{id}/process")]
        [RequirePermission(Permissions.Orders.AdminManage)]
        public async Task<ActionResult<Result<int>>> Process(int id)
        {
            return await _mediator.Send(new UpdateOrderStatusCommand { Id = id, NewStatus = OrderStatus.Processing });
        }

        /// <summary>Ship a processing order. Optionally provide a tracking number.</summary>
        [HttpPost("{id}/ship")]
        [RequirePermission(Permissions.Orders.AdminManage)]
        public async Task<ActionResult<Result<int>>> Ship(int id, [FromBody] ShipOrderRequest request)
        {
            return await _mediator.Send(new UpdateOrderStatusCommand
            {
                Id             = id,
                NewStatus      = OrderStatus.Shipped,
                TrackingNumber = request?.TrackingNumber,
            });
        }

        /// <summary>Mark a shipped order as delivered. Requires PaymentStatus = Paid.</summary>
        [HttpPost("{id}/deliver")]
        [RequirePermission(Permissions.Orders.AdminManage)]
        public async Task<ActionResult<Result<int>>> Deliver(int id)
        {
            return await _mediator.Send(new UpdateOrderStatusCommand { Id = id, NewStatus = OrderStatus.Delivered });
        }

        /// <summary>Cancel a pending, confirmed, or processing order.</summary>
        [HttpPost("{id}/cancel")]
        [RequirePermission(Permissions.Orders.AdminManage)]
        public async Task<ActionResult<Result<int>>> Cancel(int id)
        {
            return await _mediator.Send(new UpdateOrderStatusCommand { Id = id, NewStatus = OrderStatus.Cancelled });
        }

        /// <summary>
        /// Directly set order, payment, and delivery status together.
        /// Use for manual corrections and delivery preparation.
        /// Rules: Delivered requires Paid; cancelled orders cannot be set Delivered;
        /// delivered orders cannot be directly cancelled.
        /// </summary>
        [HttpPost("{id}/update-status")]
        [RequirePermission(Permissions.Orders.AdminManage)]
        public async Task<ActionResult<Result<int>>> UpdateStatus(
            int id,
            [FromBody] UpdateAdminOrderStatusCommand command)
        {
            command = command with { Id = id };

            var validator = new UpdateAdminOrderStatusCommandValidator();
            var validation = validator.Validate(command);
            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            return await _mediator.Send(command);
        }
    }

    public record ShipOrderRequest
    {
        public string? TrackingNumber { get; set; }
    }
}
