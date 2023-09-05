using ContactManagement.Dtos;
using FluentValidation;

namespace ContactManagement.Validators;

public class AddressUpdateValidator : AbstractValidator<AddressUpdateDto>
{
    public AddressUpdateValidator()
    {
        RuleFor(x => x.Street).MaximumLength(255);
        RuleFor(x => x.City).MaximumLength(100);
        RuleFor(x => x.Province).MaximumLength(100);
        RuleFor(x => x.Country).MaximumLength(100).NotEmpty();
        RuleFor(x => x.PostalCode).MaximumLength(10).NotEmpty();
    }
}