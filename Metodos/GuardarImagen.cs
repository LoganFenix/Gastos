using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;


namespace Metodos
{
   
    public enum Tamanos
    {
        Miniatura,
        Mediana
    }

    public class GuardarImagen
    {
       
            public string ResizeAndSave(string fileName, Stream imageBuffer, Tamanos tamano, bool makeItSquare)
            {
                int newWidth;
                int newHeight;
               Image image = Image.FromStream(imageBuffer);
                int oldWidth = image.Width;
                int oldHeight = image.Height;
                Bitmap newImage;
                string savePath;
                int maxSideSize;
                string urlImagen = string.Empty;

                string serverPath = HttpContext.Current.Server.MapPath("~");
                string imagesPath = serverPath + "Content\\Imagenes\\";

                if (tamano == Tamanos.Miniatura)
                {
                    urlImagen += "~/content/imagenes/Miniatura/" + fileName + ".jpg";
                    maxSideSize = 80;
                    savePath = imagesPath + "Miniatura\\" + fileName + ".jpg";
                }
                else
                {
                    urlImagen += "~/content/imagenes/Mediana/" + fileName + ".jpg";
                    maxSideSize = 600;
                    savePath = imagesPath + "Mediana\\" + fileName + ".jpg";
                }

                if (makeItSquare)
                {
                    int smallerSide = oldWidth >= oldHeight ? oldHeight : oldWidth;
                    double coeficient = maxSideSize / (double)smallerSide;
                    newWidth = Convert.ToInt32(coeficient * oldWidth);
                    newHeight = Convert.ToInt32(coeficient * oldHeight);
                    Bitmap tempImage = new Bitmap(image, newWidth, newHeight);
                    int cropX = (newWidth - maxSideSize) / 2;
                    int cropY = (newHeight - maxSideSize) / 2;
                    newImage = new Bitmap(maxSideSize, maxSideSize);
                    Graphics tempGraphic = Graphics.FromImage(newImage);
                    tempGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                    tempGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    tempGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    tempGraphic.DrawImage(tempImage, new Rectangle(0, 0, maxSideSize, maxSideSize), cropX, cropY, maxSideSize, maxSideSize, GraphicsUnit.Pixel);
                }
                else
                {
                    int maxSide = oldWidth >= oldHeight ? oldWidth : oldHeight;

                    if (maxSide > maxSideSize)
                    {
                        double coeficient = maxSideSize / (double)maxSide;
                        newWidth = Convert.ToInt32(coeficient * oldWidth);
                        newHeight = Convert.ToInt32(coeficient * oldHeight);
                    }
                    else
                    {
                        newWidth = oldWidth;
                        newHeight = oldHeight;
                    }
                    newImage = new Bitmap(image, newWidth, newHeight);
                }
                newImage.Save(savePath, ImageFormat.Jpeg);
                image.Dispose();
                newImage.Dispose();

                return urlImagen;
            }






            
    }
}
