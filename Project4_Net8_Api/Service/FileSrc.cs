using Lib_Models.Model_Table;

namespace Project4_Net8_Api.Service
{
    public class FileSrc
    {
        public static void DeleteFile(string fileName, string path)
        {
            // Đường dẫn của file cần xóa trong wwwroot/images
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            System.IO.File.Delete(filePath);
        }
        public static void AddFileInFolder_FileSrc(FileAddRequest file)
        {
            string path = file.path!;
            IFormFile fileAdd = file.file!;
            string fileNameRequest = fileAdd.FileName;
            string fileName = file.newFileName! + "." + TypeFile(fileNameRequest);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileAdd.CopyTo(fileStream);
            }
        }
        private static string TypeFile(string fileNameRequest)
        {
            int lenghtFileNameRequest = fileNameRequest.Length;
            int lastIndexOfDot = fileNameRequest.LastIndexOf('.');
            int count_Cut_FrommatFile = lenghtFileNameRequest - lastIndexOfDot;
            string text_Cut_FrommatFile = fileNameRequest.Substring(lastIndexOfDot + 1, count_Cut_FrommatFile - 1);
            return text_Cut_FrommatFile!;
        }
    }
}
