using FluentValidation;

namespace ContactManagement.Validators;

public class UserNameValidator : AbstractValidator<string>
{
    public UserNameValidator()
    {
        RuleFor(userName => userName)
            .NotEmpty()
            .MaximumLength(100)
            .WithName("userName");
    }
}