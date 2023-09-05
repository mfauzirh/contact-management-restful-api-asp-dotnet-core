using ContactManagement.Dtos;
using FluentValidation;

namespace ContactManagement.Validators;

public class ContactIdValidator : AbstractValidator<int>
{
    public ContactIdValidator()
    {
        RuleFor(contactId => contactId)
            .NotEmpty()
            .GreaterThan(0)
            .WithName("contactId");
    }
}