//namespace UtilityClass
//{
//    public class FileUController : Controller
//    {
//        public FileUController (IWebHostEnvironment webHostEnvironment)
//        {
            
//        }
//        private string ProcessUploadedFile(object? model)
//        {
//            string uniqueFilename = null;

//            if (model.Photo != null)
//            {
//                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
//                uniqueFilename = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
//                string filePath = Path.Combine(uploadsFolder, uniqueFilename);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    model.Photo.CopyTo(fileStream);
//                }
//            }

//            return uniqueFilename;
//        }
//    }
//}