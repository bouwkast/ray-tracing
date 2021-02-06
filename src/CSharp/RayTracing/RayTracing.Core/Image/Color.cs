using System.Numerics;

namespace RayTracing.Core.Image
{
    public struct Color
    {
        private const double _translation = 255.99;
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(double r, double g, double b)
        {
            R = (byte)(_translation * r);
            G = (byte)(_translation * g);
            B = (byte)(_translation * b);
        }

        public Color(Ray ray)
        {
            var unitDirection = ray.Direction / ray.Direction.Length();
            float t = (float)(0.5 * (unitDirection.Y + 1.0));
            var vectorColor = (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + (t * new Vector3(0.5f, 0.7f, 1.0f));

            R = (byte)(_translation * vectorColor.X);
            G = (byte)(_translation * vectorColor.Y);
            B = (byte)(_translation * vectorColor.Z);
        }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public override string ToString()
        {
            return $"{R} {G} {B}";
        }
    }
}
