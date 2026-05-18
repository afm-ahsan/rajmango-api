using FluentValidation;
using RajMango.Application.Common;
using System.Text.RegularExpressions;

namespace RajMango.Application.Features.Commands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Must(p => BangladeshPhoneNormalizer.IsValid(BangladeshPhoneNormalizer.Normalize(p)))
                .WithMessage("Please enter a valid Bangladesh mobile number.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .MaximumLength(255).WithMessage("Email must not exceed 255 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
                .Must(HasUppercase).WithMessage("Password must contain at least one uppercase letter.")
                .Must(HasLowercase).WithMessage("Password must contain at least one lowercase letter.")
                .Must(HasDigit).WithMessage("Password must contain at least one number.")
                .Must(HasSpecialChar).WithMessage("Password must contain at least one special character.");
        }

        private static bool HasUppercase(string p)    => p != null && Regex.IsMatch(p, "[A-Z]");
        private static bool HasLowercase(string p)    => p != null && Regex.IsMatch(p, "[a-z]");
        private static bool HasDigit(string p)        => p != null && Regex.IsMatch(p, "[0-9]");
        private static bool HasSpecialChar(string p)  => p != null && Regex.IsMatch(p, @"[^a-zA-Z0-9]");
    }
}
