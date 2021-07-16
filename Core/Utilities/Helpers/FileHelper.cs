using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string _wwwRoot = "wwwroot";

        public static string SaveImageFile(string fileName, IFormFile extension)
        {
            string resimUzantisi = Path.GetExtension(extension.FileName);
            string yeniResimAdi = string.Format("{0:D}{1}", Guid.NewGuid(), resimUzantisi);
            string imageKlasoru = Path.Combine(_wwwRoot, fileName);
            string tamResimYolu = Path.Combine(imageKlasoru, yeniResimAdi);
            string webResimYolu = string.Format("/" + fileName + "/{0}", yeniResimAdi);
            if (!Directory.Exists(imageKlasoru))
                Directory.CreateDirectory(imageKlasoru);

            using (var fileStream = File.Create(tamResimYolu))
            {
                extension.CopyTo(fileStream);
                fileStream.Flush();
            }
            return webResimYolu;
        }

        public static bool DeleteImageFile(string fileName)
        {
            string fullPath = Path.Combine(fileName);
            if (File.Exists(_wwwRoot + fullPath))
            {
                File.Delete(_wwwRoot + fullPath);
                return true;
            }
            return false;
        }
    }
}
