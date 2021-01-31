using System;
using System.IO;
using System.Text;

namespace RayTracing.Core.Image
{
    public class PPMImage
    {
        private const string PPMExtension = ".PPM";

        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Path { get; private set; }

        public Color[,] ImageData { get; private set; }

        /// <summary>
        ///     Initializes a default <see cref="PPMImage"/> with the specified <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="width">The width of the image in pixels.</param>
        /// <param name="height">The height of the image in pixels.</param>
        public PPMImage(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0");
            }

            Width = width;
            Height = height;

            ImageData = InitializeDefaultImage();
        }

        /// <summary>
        ///     Loads a <see cref="PPMImage"/> from the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        public PPMImage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Failed to find the image at {path}");
            }

            Path = path;
        }

        private Color[,] InitializeDefaultImage()
        {
            var imageData = new Color[Width, Height];

            for (int row = 0; row < Width; row++)
            {
                for (int col = 0; col < Height; col++)
                {
                    var r = (double)row / (Width - 1);
                    var g = (double)col / (Height - 1);
                    var b = 0.25;

                    imageData[row, col] = new Color(r, g, b);
                }
            }

            return imageData;
        }


        /// <summary>
        ///     Saves this <see cref="PPMImage"/> to disk at the location specified by <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to save this <see cref="PPMImage"/>.</param>
        public void Save(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace", nameof(path));
            }

            if (!System.IO.Path.HasExtension(path) || System.IO.Path.GetExtension(path) != PPMExtension)
            {
                System.IO.Path.ChangeExtension(path, PPMExtension);
            }

            var builder = new StringBuilder();
            builder.AppendLine("P3");
            builder.AppendLine($"{Width} {Height}");
            builder.AppendLine("255");

            for (int row = 0; row < Width; row++)
            {
                for (int col = 0; col < Height; col++)
                {
                    builder.AppendLine(ImageData[row, col].ToString());
                }
            }
            File.WriteAllText(path, builder.ToString());
        }
    }
}
