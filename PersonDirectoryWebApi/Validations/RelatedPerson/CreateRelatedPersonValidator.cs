using FluentValidation;
using PersonDirectoryWebApi.Models.RelatedPersons;

namespace PersonDirectoryWebApi.Validations.RelatedPerson
{
    public class CreateRelatedPersonValidator : AbstractValidator<CreateRelatedPersonDto>
    {
        public CreateRelatedPersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("The firstName field is mandatory and must not be empty.")
                .Length(2, 50).WithMessage("The firstname field must contain minimum of 2 and maximum of 50 characters")
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("The firstname field must contain only Georgian or Latin letters. The firstname column should not contain Latin and Georgian letters at the same time.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("The lastname field is mandatory and it must not be empty")
                .Length(2, 50).WithMessage("The lastname field must contain minimum of 2 and maximum of 50 characters")
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("The lastname field must contain only Georgian or Latin letters. The lastname column should not contain Latin and Georgian letters at the same time.");

            RuleFor(x => x.RelationTypeId)
                .NotEmpty().WithMessage("The RelationTypeId field is mandatory and it must not be empty")
                .IsInEnum().WithMessage("The only valid values are 1, 2, 3 and 4. 1 indicates a Colleague, 2 indicates an Acquaintance, 3 indicates a Relative and 4 indicates an Other.");
        }
    }
}
