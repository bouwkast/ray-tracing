namespace RayTracing.Core.Image
{
    public struct Color
    {
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
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
