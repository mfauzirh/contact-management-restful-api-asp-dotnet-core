using FluentValidation;

namespace ContactManagement.Validators;

public class AddressId : AbstractValidator<int>
{
    public AddressId()
    {
        RuleFor(addressId => addressId)
            .NotEmpty()
            .GreaterThan(0)
            .WithName("addressId");
    }
}