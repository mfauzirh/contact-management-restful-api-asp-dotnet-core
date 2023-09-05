using ContactManagement.Dtos;
using FluentValidation;

namespace ContactManagement.Validators;

public class ContactSearchValidator : AbstractValidator<ContactSearchDto>
{
    public ContactSearchValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100);
        RuleFor(x => x.Email)
            .MaximumLength(100);
        RuleFor(x => x.Phone)
            .MaximumLength(100);
        RuleFor(x => x.Page)
            .GreaterThan(0);
        RuleFor(x => x.Size)
            .GreaterThan(0);
    }
}