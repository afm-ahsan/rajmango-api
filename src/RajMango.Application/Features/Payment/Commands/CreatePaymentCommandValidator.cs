using FluentValidation;

namespace RajMango.Application.Features.Commands
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("A valid order must be specified.");

            RuleFor(x => x.PaidAmount)
                .GreaterThan(0).WithMessage("Paid amount must be greater than zero.");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum().WithMessage("A valid payment method must be selected.");
        }
    }
}
