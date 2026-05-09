using FluentValidation;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Commands
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("A valid user is required.");

            RuleFor(x => x.OrderDetails)
                .NotEmpty()
                .WithMessage("At least one order line is required.");

            RuleFor(x => x.OrderDetails)
                .Must(details => details != null && details.All(d => d.Quantity > 0))
                .WithMessage("Each order line must have a quantity greater than zero.");

            RuleFor(x => x.OrderDetails)
                .Must(HaveMinimumTotalQuantity)
                .WithMessage("Minimum order quantity is 10 kg.");
        }

        private static bool HaveMinimumTotalQuantity(CreateOrderCommand command, IEnumerable<DTOs.Order.OrderDetailInputDto> details)
        {
            if (details == null) return false;
            var total = details.Sum(d => d.Quantity * DomainUtils.GetCrateWeight(d.CrateType));
            return total >= 10;
        }
    }
}
