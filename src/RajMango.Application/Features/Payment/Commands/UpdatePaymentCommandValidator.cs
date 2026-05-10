using FluentValidation;

namespace RajMango.Application.Features.Commands
{
    public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("A valid payment Id must be provided.");

            RuleFor(x => x.PaidAmount)
                .GreaterThan(0).WithMessage("Paid amount must be greater than zero.");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum().WithMessage("A valid payment method must be selected.");
        }
    }
}
