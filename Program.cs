using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace j_strcmp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) Environment.Exit(1);

            string input = args[0];
            Font font = new Font(FontFamily.Families.First(x => x.Name == "Arial"), 500);
            string filePath = Directory.GetCurrentDirectory() + "/file_new.png";

            SizeF inputSize; Bitmap bitmap; Graphics graphic;

            using (bitmap = new Bitmap(1, 1))
            using (graphic = Graphics.FromImage(bitmap))
            {
                inputSize = graphic.MeasureString(input, font);
            }

            using (bitmap = new Bitmap((int)inputSize.Width, (int)inputSize.Height))
            using (graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                graphic.DrawString(input, font, new SolidBrush(Color.Black), 0, 0);
                graphic.Save();
                bitmap.Save(filePath, ImageFormat.Png);
            }
        }
    }
}
