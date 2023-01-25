namespace PersonDirectoryWebApi.Services.IRepositories
{
    public interface IImageRepository
    {
        Task<string> UploadImage(IFormFile imageFile);
    }
}
