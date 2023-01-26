using FluentValidation;
using PersonDirectoryWebApi.Requests.PhoneNumberRequests;

namespace PersonDirectoryWebApi.Validations.PhoneNumber
{
    public class CreatePhoneNumberValidator : AbstractValidator<CreatePhoneNumbersRequestDto>
    {
        public CreatePhoneNumberValidator()
        {
            RuleFor(x => x.PhoneNumbers)
                .NotEmpty().WithMessage("The PhoneNumber field is mandatory and must not be empty.")
                .Length(4, 50).WithMessage("The minimum length of PhoneNumber field is 4 digits and maximum length is 50 digits.");

            RuleFor(x => x.NumberTypeId)
                .NotEmpty().WithMessage("The NumberTypeId field is mandatory and it must not be empty")
                .IsInEnum().WithMessage("The only valid values are 1, 2 and 3. 1 indicates a mobile number type, 2 indicates an office number type and 3 indicates a home number type.");
        }
    }
}
