using Microsoft.AspNetCore.Hosting;

namespace HydroPathSystemAPI.Helpers
{
    public class FileHandler
    {

        public static void RemoveFileFromStorage(string imagePath, IWebHostEnvironment hostingEnvironment)
        {

            string wwwRootPath = hostingEnvironment.WebRootPath;

            // Combine the wwwroot path with the relative path
            string path = Path.Combine(wwwRootPath, imagePath);


            // delete the file to the specified path
            try
            {
                FileInfo file = new FileInfo(path);

                if (file.Exists)//check file exsit or not  
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("invalid path");
            }


        }

        public static async Task<string?> SaveFileToStorage(string base64String, string fileType = null)
        {// Find the index of the comma ","
            int commaIndex = base64String.IndexOf(',');

            // Check if the comma exists and remove the prefix
            if (commaIndex != -1)
            {
                base64String = base64String.Substring(commaIndex + 1);
            }
            else if (base64String.StartsWith("data:image/png;base64,"))
            {
                base64String = base64String.Substring("data:image/png;base64,".Length);
            }

            Console.WriteLine(base64String);

            if (base64String == null)
            {
                return null;
            }
            string fileName ="";
            if (fileType == null || fileType.Contains("image"))
            {
                fileName = $"{Guid.NewGuid().ToString()}.png";

            }
            if (fileType != null && fileType.Contains("pdf"))
            {
                fileName = $"{Guid.NewGuid().ToString()}.pdf";

            }
            if (fileType != null && fileType.Contains("audio"))
            {
                fileName = $"{Guid.NewGuid().ToString()}.mp3";

            }

            byte[] bytes;
            try
            {
                // Convert base64 string to bytes
                bytes = Convert.FromBase64String(base64String);
            }
            catch (FormatException e)
            {
                throw new Exception(e.Message);
            }

            // Define the path where file will be saved (e.g., wwwroot/attachements)
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "attachements", fileName);

            // Save the file to the specified path
            try
            {
                await File.WriteAllBytesAsync(path, bytes);

                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }



        }

        public static string GetImageAsBase64FromPath(string imagePath, IWebHostEnvironment hostingEnvironment)
        {
            try
            {
                string wwwRootPath = hostingEnvironment.WebRootPath;

                // Combine the wwwroot path with the relative path
                string path = Path.Combine(wwwRootPath, imagePath);
                // Read the image file
                byte[] imageBytes = System.IO.File.ReadAllBytes(path);

                // Convert byte array to Base64 string
                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
