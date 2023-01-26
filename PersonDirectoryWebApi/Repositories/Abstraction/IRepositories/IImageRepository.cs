namespace PersonDirectoryWebApi.Repositories.Abstraction.IRepositories
{
    public interface IImageRepository
    {
        Task<string> UploadImage(IFormFile imageFile);
    }
}
