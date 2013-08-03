using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace inln_bootstrap.Utils
{
    public static class FileManager
    {
        public static string UploadFile(HttpPostedFileBase file, string folderName, Guid guidId)
        {
            // пришел ли файл
            if (file == null)
            {
                return "";
            }

            // подходит ли файл по mime-типу
            if (!file.ContentType.Equals("image/jpeg") && !file.ContentType.Equals("image/png") && !file.ContentType.Equals("image/gif"))
            {
                return "";
            }

            string fileName = Path.GetFileName(file.FileName);

            // получаем расширение файла
            string fileExtension = Path.GetExtension(file.FileName);
            // формируем физический путь до папки сохранения
            string folderPath = HttpContext.Current.Server.MapPath(Path.Combine("~\\Uploads\\", folderName, guidId.ToString()));

            // существует ли папка сохранения
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // формируем физический путь файла для сохранения
            string filePath = Path.Combine(folderPath, fileName + fileExtension);
            // формируем виртуальный путь файла
            string filePathVirtual = "~/Uploads/" + folderName + "/" + guidId.ToString() + "/" + fileName + fileExtension;
            file.SaveAs(filePath);

            return filePathVirtual;
        }

        public static string UploadFile(HttpPostedFileBase file, string folderName, Guid guidId, string fileName)
        {
            // пришел ли файл
            if (file == null)
            {
                return "";
            }

            // подходит ли файл по mime-типу
            if (!file.ContentType.Equals("image/jpeg") && !file.ContentType.Equals("image/png") && !file.ContentType.Equals("image/gif"))
            {
                return "";
            }

            // получаем расширение файла
            string fileExtension = Path.GetExtension(file.FileName);
            // формируем физический путь до папки сохранения
            string folderPath = HttpContext.Current.Server.MapPath(Path.Combine("~\\Uploads\\", folderName, guidId.ToString()));

            // существует ли папка сохранения
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // формируем физический путь файла для сохранения
            string filePath = Path.Combine(folderPath, fileName + fileExtension);
            // формируем виртуальный путь файла
            string filePathVirtual = "~/Uploads/" + folderName + "/" + guidId.ToString() + "/" + fileName + fileExtension;
            file.SaveAs(filePath);

            return filePathVirtual;
        }

        public static string DeleteFile(string filePath)
        {
            // формируем физический путь до удаляемого файла
            string filePathPhysical = HttpContext.Current.Server.MapPath(filePath);

            // существует ли удаляемый файл
            if (File.Exists(filePathPhysical))
            {
                File.Delete(filePathPhysical);
            }
            return "";
        }

        public static string UpdateFile(string oldFilePath, HttpPostedFileBase file, string folderName, Guid guidId)
        {
            string returnUrl;

            // пришел ли новый файл
            if (file == null)
            {
                return oldFilePath;
            }

            // подходит ли файл по mime-типу
            if (!file.ContentType.Equals("image/jpeg") && !file.ContentType.Equals("image/png") && !file.ContentType.Equals("image/gif"))
            {
                return oldFilePath;
            }
            // удалять ли старый файл
            if (!String.IsNullOrEmpty(oldFilePath))
            {
                returnUrl = DeleteFile(oldFilePath);
            }
            returnUrl = UploadFile(file, folderName, guidId);
            return returnUrl;
        }

        public static string UpdateFile(string oldFilePath, HttpPostedFileBase file, string folderName, Guid guidId, string fileName)
        {
            string returnUrl;

            // пришел ли новый файл
            if (file == null)
            {
                return oldFilePath;
            }

            // подходит ли файл по mime-типу
            if (!file.ContentType.Equals("image/jpeg") && !file.ContentType.Equals("image/png") && !file.ContentType.Equals("image/gif"))
            {
                return oldFilePath;
            }
            // удалять ли старый файл
            if (!String.IsNullOrEmpty(oldFilePath))
            {
                returnUrl = DeleteFile(oldFilePath);
            }
            returnUrl = UploadFile(file, folderName, guidId, fileName);
            return returnUrl;
        }
    }
}