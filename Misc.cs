using System;
namespace NoiseLibrary
{
    public static class Misc
    {
        public static double Lerp(double s, double v1, double v2)
        {
            return v1 + s * (v2 - v1);
        }

        public static double Clamp(double value, double max, double min)
        {
            double result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }

    }
}

