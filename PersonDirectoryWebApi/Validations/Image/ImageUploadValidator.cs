using FluentValidation;
using PersonDirectoryWebApi.Requests.ImageRequests;

namespace PersonDirectoryWebApi.Validations.Image
{
    public class ImageUploadValidator : AbstractValidator<ImageUploadRequestDto>
    {
        public ImageUploadValidator()
        {
            RuleFor(x => x.personId)
                .NotEmpty().WithMessage("The personId  must not be empty")
                .NotNull().WithMessage("The personId  must not be null");
        }
    }
}
