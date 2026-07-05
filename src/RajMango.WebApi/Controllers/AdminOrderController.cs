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

        /// <summary>
        /// Create an order on behalf of an existing customer.
        /// The customer owns the order (appears in their dashboard/list/totals);
        /// the logged-in admin is recorded in PlacedByAdminUserId for audit.
        /// </summary>
        [HttpPost("create-for-customer")]
        [RequirePermission(Permissions.Orders.AdminCreateForCustomer)]
        public async Task<ActionResult<Result<int>>> CreateForCustomer(
            [FromBody] CreateOrderForCustomerCommand command)
        {
            var validator = new CreateOrderForCustomerCommandValidator();
            var validation = validator.Validate(command);
            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            return await _mediator.Send(command);
        }

        /// <summary>Paged order list with rich filters for admin management.</summary>
        [HttpGet]
        [RequirePermission(Permissions.Orders.AdminView)]
        public async Task<ActionResult<AdminOrderPaginatedResult>> GetPaged([FromQuery] GetAdminOrderListQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Typeahead search for customer users (self-register role only).
        /// Used by admin when placing an order on behalf of a customer.
        /// Returns up to 20 matches on name, phone, or email.
        /// </summary>
        [HttpGet("customer-search")]
        [RequirePermission(Permissions.Orders.AdminCreateForCustomer)]
        public async Task<ActionResult<Result<List<AdminCustomerSearchResultDto>>>> CustomerSearch(
            [FromQuery] string q)
        {
            return await _mediator.Send(new AdminCustomerSearchQuery { Q = q });
        }

        /// <summary>
        /// Typeahead order search for the Record Payment flow.
        /// Searches by Order Number (partial match); returns financials so the modal
        /// can auto-populate Total, Paid, Due, and PaymentStatus without a second request.
        /// Returns up to 10 results. Requires payment.create permission.
        /// </summary>
        [HttpGet("payment-lookup")]
        [RequirePermission(Permissions.Payments.Create)]
        public async Task<ActionResult<Result<List<OrderPaymentLookupDto>>>> PaymentLookup(
            [FromQuery] string search)
        {
            return await _mediator.Send(new GetOrderPaymentLookupQuery { Search = search });
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
        /// Permanently remove an order from all lists, dashboards, and totals
        /// by soft-deleting it (and its linked payments) with a full audit snapshot.
        ///
        /// The admin must supply the exact order number to confirm the action.
        /// The deletion is irreversible from the UI; a DBA can reverse it via the DB if needed.
        /// </summary>
        [HttpDelete("{id}/permanent-delete")]
        [RequirePermission(Permissions.Orders.AdminDeletePermanent)]
        public async Task<ActionResult<Result<int>>> PermanentDelete(
            int id,
            [FromBody] AdminPermanentDeleteRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.ConfirmOrderNumber))
                return BadRequest("Order number confirmation is required.");

            if (string.IsNullOrWhiteSpace(request.Reason))
                return BadRequest("A reason for deletion is required.");

            return await _mediator.Send(new AdminPermanentDeleteOrderCommand
            {
                OrderId             = id,
                ConfirmOrderNumber  = request.ConfirmOrderNumber,
                Reason              = request.Reason,
            });
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

    public record AdminPermanentDeleteRequest
    {
        /// <summary>Admin must type the order number exactly — confirmed server-side too.</summary>
        public string ConfirmOrderNumber { get; set; }
        public string Reason { get; set; }
    }
}
