using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Restaurant_app.Helper
{
    public class ImageResizeHelper
    {
        public static void ImageResizer(string imgPath, int Width, int Height)
        {
            FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var img = new WebImage(fs);
            if (img.Width > Width || img.Height > Height)
                img.Resize(Width, Height);
            img.Save(imgPath);
            fs.Close();
        }
    }
}