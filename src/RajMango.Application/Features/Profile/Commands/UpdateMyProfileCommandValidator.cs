using FluentValidation;
using System.Text.RegularExpressions;

namespace RajMango.Application.Features.Commands
{
    public class UpdateMyProfileCommandValidator : AbstractValidator<UpdateMyProfileCommand>
    {
        public UpdateMyProfileCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters.");

            // Password change rules — only applied when NewPassword is provided
            When(x => !string.IsNullOrWhiteSpace(x.NewPassword), () =>
            {
                RuleFor(x => x.CurrentPassword)
                    .NotEmpty().WithMessage("Current password is required to set a new password.");

                RuleFor(x => x.NewPassword)
                    .MinimumLength(6).WithMessage("New password must be at least 6 characters.")
                    .Must(HasUppercase).WithMessage("New password must contain at least one uppercase letter.")
                    .Must(HasLowercase).WithMessage("New password must contain at least one lowercase letter.")
                    .Must(HasDigit).WithMessage("New password must contain at least one number.")
                    .Must(HasSpecialChar).WithMessage("New password must contain at least one special character.");
            });
        }

        private static bool HasUppercase(string p)   => p != null && Regex.IsMatch(p, "[A-Z]");
        private static bool HasLowercase(string p)   => p != null && Regex.IsMatch(p, "[a-z]");
        private static bool HasDigit(string p)       => p != null && Regex.IsMatch(p, "[0-9]");
        private static bool HasSpecialChar(string p) => p != null && Regex.IsMatch(p, @"[^a-zA-Z0-9]");
    }
}
