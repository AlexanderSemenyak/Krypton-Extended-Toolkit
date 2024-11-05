﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class NumericExtensions
    {
        public static bool IsInfiniteOrNaN(this double x)
        {
            return !IsFinite(x);
        }

        public static bool IsFinite(this double x)
        {
            if (double.IsInfinity(x))
            {
                return false;
            }

            return !double.IsNaN(x);
        }

        public static float ToDegrees(this double radians)
        {
            return (float)(radians * 180.0 / Math.PI);
        }

        public static float ToRadians(this double degrees)
        {
            return (float)(degrees / 180.0 * Math.PI);
        }

        public static float ToRadians(this float degrees)
        {
            return (float)(degrees / 180.0 * Math.PI);
        }

        public static float ToRadians(this int degrees)
        {
            return (float)(degrees / 180.0 * Math.PI);
        }

        /// <summary>
        /// Returns the fallback value if the given value is infinity
        /// </summary>
        public static double FiniteCoallesce(this double value, double fallback)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
            {
                return fallback;
            }
            else
            {
                return value;
            }
        }
    }
}