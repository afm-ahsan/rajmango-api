using MediatR;
using RajMango.Application.DTOs.Order;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    /// <summary>
    /// Admin-only command: place an order on behalf of an existing customer.
    ///
    /// Ownership model:
    ///   Order.UserId              = TargetCustomerId  (customer owns / sees the order)
    ///   Order.PlacedByAdminUserId = logged-in admin   (explicit audit trail)
    ///   Order.CreatedBy           = logged-in admin   (auto-populated by AuditingHelper)
    ///   Order.IsPlacedByAdmin     = true
    ///
    /// The order appears in the customer's dashboard, order list, and totals exactly as
    /// if the customer had placed it themselves.
    /// </summary>
    public record CreateOrderForCustomerCommand : IRequest<Result<int>>
    {
        /// <summary>AppUser.Id of the customer for whom the order is being placed.</summary>
        public int TargetCustomerId { get; set; }

        public int? CourierStationId { get; set; }

        public string FallbackAddress { get; set; }

        public ReceiverType ReceiverType { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverMobileNumber { get; set; }

        public string DeliveryNote { get; set; }

        public IEnumerable<OrderDetailInputDto> OrderDetails { get; set; }
    }
}
