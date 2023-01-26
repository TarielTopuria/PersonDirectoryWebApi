using FluentValidation;
using PersonDirectoryWebApi.Requests.PersonRequests;

namespace PersonDirectoryWebApi.Validations.Person
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonRequestDto>
    {
        public UpdatePersonValidator()
        {
            RuleFor(X => X.FirstName)
                .NotEmpty().WithMessage("The firstname field is mandatory and it must not be empty")
                .Length(2, 50).WithMessage("The firstname field must contain minimum of 2 and maximum of 50 characters")
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("The firstname field must contain only Georgian or Latin letters. The firstname column should not contain Latin and Georgian letters at the same time.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("The lastname field is mandatory and it must not be empty")
                .Length(2, 50).WithMessage("The lastname field must contain minimum of 2 and maximum of 50 characters")
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("The lastname field must contain only Georgian or Latin letters. The lastname column should not contain Latin and Georgian letters at the same time.");

            RuleFor(x => x.GenderId)
                .NotEmpty().WithMessage("The GenderId field is mandatory and it must not be empty")
                .IsInEnum().WithMessage("The only valid values are 1 and 2. where 1 indicates a male and 2 indicates a female.");

            RuleFor(x => x.PersonalNumber)
                .NotNull().WithMessage("The PersonalNumber field must not be null")
                .NotEmpty().WithMessage("The PersonalNumber field is mandatory and it must not be empty")
                .Length(11).WithMessage("The PersonalNumber field must contain only 11 digits")
                .Matches("^[0-9]*$").WithMessage("The PersonalNumber field must contain only digits");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("The DateOfBirth field is mandatory and it must not be empty")
                .Must(d => d.AddYears(18) < DateTime.Now).WithMessage("Minimal age of a person must be 18");

            RuleFor(x => x.CityId)
                .NotNull().WithMessage("The cityId field must not be null")
                .NotEmpty().WithMessage("The cityId field must not be empty")
                .LessThanOrEqualTo(10).WithMessage("There is only 10 cities");
        }
    }
}
