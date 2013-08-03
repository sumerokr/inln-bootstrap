using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace inln_bootstrap.Utils
{
    public static class ImageHandler
    {
        public static string ResizeAndCrop(string imagePath, string folderName, Guid guidId, int width, int height)
        {
            if (String.IsNullOrEmpty(imagePath))
            {
                return "";
            }
            string fileName = Path.GetFileName(imagePath);
            string filePathPhysical = HttpContext.Current.Server.MapPath(imagePath);
            string thumbFolderPath = HttpContext.Current.Server.MapPath(Path.Combine("~\\Thumbs\\", folderName, guidId.ToString(), width.ToString() + "x" + height.ToString()));
            string thumbFilePathVirtual = "~/Thumbs/" + folderName + "/" + guidId.ToString() + "/" + width.ToString() + "x" + height.ToString() + "/" + fileName;
            string thumbFilePathPhysical = HttpContext.Current.Server.MapPath(Path.Combine("~\\Thumbs\\", folderName, guidId.ToString(), width.ToString() + "x" + height.ToString(), fileName));

            if (!Directory.Exists(thumbFolderPath))
            {
                Directory.CreateDirectory(thumbFolderPath);
            }

            if (File.Exists(thumbFilePathPhysical))
            {
                return thumbFilePathVirtual;
            }

            WebImage image = new WebImage(filePathPhysical);
            
            int originalWidth = image.Width;
            int originalHeight = image.Height;
            float originalRatio = (float)originalWidth / (float)originalHeight;

            float ratio = (float)(width) / (float)(height);

            if (ratio > originalRatio)
            {
                image.Resize(width, 9999, true, false);
                int overSize = image.Height - height;
                int toCrop = overSize / 2;
                int cropFix = 0;
                if (overSize % 2 != 0)
                {
                    cropFix = 1;
                }
                image.Crop(toCrop, 0, (toCrop + cropFix), 0);
            }
            else if (ratio < originalRatio)
            {
                image.Resize(9999, height, true, false);
                int overSize = image.Width - width;
                int toCrop = overSize / 2;
                int cropFix = 0;
                if (overSize % 2 != 0)
                {
                    cropFix = 1;
                }
                image.Crop(0, (toCrop + cropFix), 0, toCrop);
            }
            else
            {
                image.Resize(width, height, true, false);
            }
            image.Save(thumbFilePathPhysical);
            return thumbFilePathVirtual;
        }
    }
}