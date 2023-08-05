using Microsoft.AspNetCore.Hosting;

namespace AppNest_Project.Services.FileServices
{
    public class FileServices : IFileServices
    {
        private IWebHostEnvironment _webHostEnvironment;
        public FileServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Tuple<int, string>> SaveImage(List<IFormFile> imageFiles)
        {
            var results = new List<Tuple<int, string>>();

            try
            {
                var contentPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentPath, "wwwroot/Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var allowedExtensions = new string[] { ".jpg", ".jfif", ".png", ".svg", ".jpeg" };

                foreach (var imageFile in imageFiles)
                {
                    var ext = Path.GetExtension(imageFile.FileName);

                    if (!allowedExtensions.Contains(ext))
                    {
                        results.Add(Tuple.Create(0, "Invalid file type"));
                        continue;
                    }

                    var unique = Guid.NewGuid().ToString();
                    var newFileName = unique + ext;
                    var filePath = Path.Combine(path, newFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    results.Add(Tuple.Create(1, newFileName));
                }
            }
            catch (Exception ex)
            {
                results.Add(Tuple.Create(0, "Error occurred while saving the image"));
            }

            return results;
        }

       
    }
}
