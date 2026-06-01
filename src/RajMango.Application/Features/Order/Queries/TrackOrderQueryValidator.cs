using FluentValidation;

namespace RajMango.Application.Features.Queries
{
    public class TrackOrderQueryValidator : AbstractValidator<TrackOrderQuery>
    {
        public TrackOrderQueryValidator()
        {
            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Order number is required.")
                .MaximumLength(50);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20);
        }
    }
}
