using FluentValidation;

namespace RajMango.Application.Features.Commands
{
    public class CreateMangoTypeCommandValidator : AbstractValidator<CreateMangoTypeCommand>
    {
        public CreateMangoTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Mango type name is required.")
                .MaximumLength(100).WithMessage("Mango type name must not exceed 100 characters.");

            RuleFor(x => x.MangoGrade)
                .IsInEnum().WithMessage("A valid mango grade must be selected.");

            RuleFor(x => x.SweetnessLevel)
                .IsInEnum().WithMessage("A valid sweetness level must be selected.")
                .Must(s => s != 0).WithMessage("Sweetness level is required.");
        }
    }
}
