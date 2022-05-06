using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LazZiya.ImageResize;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Drawing;

namespace Ultilities
{
    public static class FileService
    {
        public static string Upload(IFormFile file, string physicalPath, string webRootPath)
        {
            try
            {
                if (file == null) return null;

                if (!Directory.Exists(physicalPath))
                    Directory.CreateDirectory(physicalPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(webRootPath, fileName);
                var targetPath = Path.Combine(physicalPath, fileName);

                using (var strem = File.Create(targetPath))
                {
                    file.CopyTo(strem);
                }
                return filePath;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //public File Download(string filePath)
        //{
        //    if (filePath == null) return null;
        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(filePath, FileMode.Open))
        //    {
        //        stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;
        //    return File(memory, GetContentType(filePath), Path.GetFileName(filePath)); 
        //}
        private static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public static bool IsImage(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            List<string> jpg = new List<string> { "FF", "D8" };
            List<string> bmp = new List<string> { "42", "4D" };
            List<string> gif = new List<string> { "47", "49", "46" };
            List<string> png = new List<string> { "89", "50", "4E", "47", "0D", "0A", "1A", "0A" };
            List<List<string>> imgTypes = new List<List<string>> { jpg, bmp, gif, png };

            List<string> bytesIterated = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                string bit = stream.ReadByte().ToString("X2");
                bytesIterated.Add(bit);

                bool isImage = imgTypes.Any(img => !img.Except(bytesIterated).Any());
                if (isImage)
                {
                    return true;
                }
            }

            return false;
        }
        public static string ScaleImage(string originalImagePath, IFormFile originalImage)
        {
            try
            {
                var image = SixLabors.ImageSharp.Image.Load(originalImage.OpenReadStream());
                if(image.Height * image.Width > 320000)
                {
                    var width = Convert.ToInt32(image.Width * 0.5);
                    int height = Convert.ToInt32(image.Height * 0.5);
                    var img = System.Drawing.Image.FromFile($@"wwwroot/{originalImagePath}");
                    var scaleImg = ImageResize.Scale(img, width, height);
                    var array = originalImagePath.Split('.');
                    array[0] = $@"{array[0]}-thumb";
                    var scaledPath = string.Join(".", array);
                    scaleImg.SaveAs($@"wwwroot/{scaledPath}");
                    return scaledPath;
                }
                return originalImagePath;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
