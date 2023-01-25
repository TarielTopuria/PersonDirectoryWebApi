using FluentValidation;
using PersonDirectoryWebApi.Models.ImageModels;
using PersonDirectoryWebApi.Services.IRepositories;

namespace PersonDirectoryWebApi.Validations.Image
{
    public class ImageUploadValidator : AbstractValidator<ImageUploadDto>
    {
        public ImageUploadValidator()
        {
            RuleFor(x => x.personId)
                .NotEmpty().WithMessage("The personId  must not be empty")
                .NotNull().WithMessage("The personId  must not be null");
        }
    }
}
