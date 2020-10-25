using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;

namespace j_strcmp
{
    class ImageCreator
    {
        static readonly string FilePathFormat = Directory.GetCurrentDirectory() + @"\{0}.tif";

        internal static string CreateImage(string word)
        {
            Font font = new Font(FontFamily.Families.First(x => x.Name == "Arial"), 500);
            string filePath = string.Format(FilePathFormat, "input");
            SizeF inputSize; Bitmap bitmap; Graphics graphic;

            using (bitmap = new Bitmap(1, 1))
            using (graphic = Graphics.FromImage(bitmap))
            {
                inputSize = graphic.MeasureString(word, font);
            }

            using (bitmap = new Bitmap((int)inputSize.Width, (int)inputSize.Height))
            using (graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                graphic.DrawString(word, font, new SolidBrush(Color.Black), 0, 0);
                graphic.Save();
                bitmap.Save(filePath, ImageFormat.Tiff);

                return filePath;
            }
        }
    }
}