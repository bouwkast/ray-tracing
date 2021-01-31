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

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public override string ToString()
        {
            return $"{R} {G} {B}";
        }
    }
}
