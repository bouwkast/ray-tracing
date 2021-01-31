using RayTracing.Core.Image;
using System;

namespace RayTracing
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("hi");

            var imagePath = "test.ppm";

            var ppmImage = new PPMImage(256, 256);

            ppmImage.Save(imagePath);
        }
    }
}
