namespace AppNest_Project.Services.FileServices
{
    public interface IFileServices
    {
        List<Tuple<int, string>> SaveImage(List<IFormFile> imageFiles);
    }
}
