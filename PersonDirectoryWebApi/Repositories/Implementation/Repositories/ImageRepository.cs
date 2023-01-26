using PersonDirectoryWebApi.Repositories.Abstraction.IRepositories;

namespace PersonDirectoryWebApi.Repositories.Implementation.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-') + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var destinationFolder = "Images";
            var imagePath = $@"{destinationFolder}/{imageName}";

            Directory.CreateDirectory(destinationFolder);

            await using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imagePath;
        }
    }
}
