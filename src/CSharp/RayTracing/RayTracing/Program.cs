using RayTracing.Core.Image;
using System;
using System.Numerics;

namespace RayTracing
{
    public static class Program
    {
        public static void Main()
        {
            // image params
            const double aspectRatio = 16.0 / 9.0;
            const int width = 400;
            const int height = (int)(width / aspectRatio);

            // camera params
            float viewportHeight = 2.0f;
            float viewportWidth = (float)(aspectRatio * viewportHeight);
            float focalLength = 1.0f;

            var origin = new Vector3(0, 0, 0);
            var horizontal = new Vector3(viewportWidth, 0, 0);
            var vertical = new Vector3(0, viewportHeight, 0);
            var lowerLeftCorner = origin - horizontal / 2 - vertical / 2 - new Vector3(0, 0, focalLength);

            var imagePath = "test.ppm";

            var ppmImage = new PPMImage(width, height, origin, horizontal, vertical, lowerLeftCorner);
            //var ppmImage = new PPMImage(256, 256);

            ppmImage.Save(imagePath);
        }
    }
}
