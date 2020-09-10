using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"同步版本 花費時間: {sw.ElapsedMilliseconds} ms");

            var msAsync = ResizeImageAsync().Result;
            

            Console.ReadKey();
        }

        private static async Task<long> ResizeImageAsync()
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output-async"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"異步版本 花費時間: {sw.ElapsedMilliseconds} ms");

            return sw.ElapsedMilliseconds;
        }
    }
}
