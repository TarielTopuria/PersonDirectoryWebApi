namespace PersonDirectoryWebApi.Requests.ImageRequests
{
    public class ImageUploadRequestDto
    {
        public int personId { get; set; }
        public IFormFile Image { get; set; }
    }
}
