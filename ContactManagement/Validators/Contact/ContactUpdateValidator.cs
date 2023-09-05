using ContactManagement.Dtos;
using FluentValidation;

namespace ContactManagement.Validators;

public class ContactUpdateValidator : AbstractValidator<ContactUpdateDto>
{
    public ContactUpdateValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(100).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(100);
        RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
        RuleFor(x => x.Phone).MaximumLength(100);
    }
}