using ContactManagement.Dtos;
using FluentValidation;

namespace ContactManagement.Validators;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.UserName).MaximumLength(100).NotEmpty();
        RuleFor(x => x.Password).MaximumLength(100).NotEmpty();
    }
}