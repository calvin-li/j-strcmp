using System;
using System.IO;

namespace j_strcmp
{
    class Program
    {

        static int Main(string[] args)
        {
            if (args.Length != 1) Environment.Exit(1);

            string input = args[0];
            string inputFile = ImageCreator.CreateImage(input);
            OCR.OcrImage(inputFile);

            foreach(string word in OCR.Forbidden)
            {
                if (input.Equals(word)) return 1; // sanity check
                ImageCreator.CreateImage(word);
            }
            return 0;
        }
    }
}