using FluentValidation;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public class UpdateAdminOrderStatusCommandValidator : AbstractValidator<UpdateAdminOrderStatusCommand>
    {
        public UpdateAdminOrderStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("A valid order Id is required.");

            RuleFor(x => x.OrderStatus)
                .IsInEnum().WithMessage("A valid order status must be specified.");

            RuleFor(x => x.PaymentStatus)
                .IsInEnum().WithMessage("A valid payment status must be specified.");

            RuleFor(x => x.DeliveryStatus)
                .IsInEnum().WithMessage("A valid delivery status must be specified.");

            // Delivered requires Paid payment
            When(x => x.DeliveryStatus == DeliveryStatus.Delivered, () =>
            {
                RuleFor(x => x.PaymentStatus)
                    .Must(p => p == PaymentStatus.Paid)
                    .WithMessage("Payment status must be Paid when delivery status is Delivered.");

                RuleFor(x => x.OrderStatus)
                    .Must(s => s != OrderStatus.Cancelled)
                    .WithMessage("A cancelled order cannot be marked as Delivered.");
            });
        }
    }
}
