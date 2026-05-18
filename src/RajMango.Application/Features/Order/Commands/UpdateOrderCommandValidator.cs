using FluentValidation;
using RajMango.Shared.Enums;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Commands
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("A valid order Id is required.");

            RuleFor(x => x.ReceiverType)
                .IsInEnum()
                .WithMessage("Receiver type must be Self or Others.");

            When(x => x.ReceiverType == ReceiverType.Others, () =>
            {
                RuleFor(x => x.ReceiverName)
                    .NotEmpty()
                    .WithMessage("Receiver name is required when delivering to someone else.")
                    .MaximumLength(100);

                RuleFor(x => x.ReceiverMobileNumber)
                    .NotEmpty()
                    .WithMessage("Receiver mobile number is required when delivering to someone else.")
                    .MaximumLength(20);
            });

            RuleFor(x => x.OrderDetails)
                .NotEmpty()
                .WithMessage("At least one order line is required.");

            RuleFor(x => x.OrderDetails)
                .Must(details => details != null && details.All(d => d.Quantity > 0))
                .WithMessage("Each order line must have a quantity greater than zero.");

            RuleFor(x => x.OrderDetails)
                .Must(HaveValidCrateTypes)
                .WithMessage("Each order line must specify a valid crate size (10 kg or 20 kg).");

            RuleFor(x => x.OrderDetails)
                .Must(HaveMinimumTotalWeight)
                .WithMessage("Minimum order is 10 kg. Please add at least one 10 kg or 20 kg crate.");
        }

        private static bool HaveValidCrateTypes(IEnumerable<DTOs.Order.OrderDetailInputDto> details)
        {
            if (details == null) return false;
            return details.All(d => d.CrateType == CrateType.Crate10Kg || d.CrateType == CrateType.Crate20Kg);
        }

        private static bool HaveMinimumTotalWeight(IEnumerable<DTOs.Order.OrderDetailInputDto> details)
        {
            if (details == null) return false;
            var totalKg = details.Sum(d => d.Quantity * DomainUtils.GetCrateWeight(d.CrateType));
            return totalKg >= 10;
        }
    }
}
