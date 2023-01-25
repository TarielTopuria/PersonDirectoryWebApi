namespace PersonDirectoryWebApi.Models.ImageModels
{
    public class ImageUploadDto
    {
        public int personId { get; set; }
        public IFormFile Image { get; set; }
    }
}
