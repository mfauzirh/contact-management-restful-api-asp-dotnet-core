using ContactManagement.Dtos;
using FluentValidation;

namespace ContactManagement.Validators;

public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.UserName).MaximumLength(100).NotEmpty();
        RuleFor(x => x.Password).MaximumLength(100).NotEmpty();
        RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
    }
}