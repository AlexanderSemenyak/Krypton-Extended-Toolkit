﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Represents a series of data points with distinct X and Y positions in coordinate space.
    /// </summary>
    public interface IScatterSource
    {
        /// <summary>
        /// Return a copy of the data in <see cref="Coordinates"/> format.
        /// </summary>
        IReadOnlyList<Coordinates> GetScatterPoints(); // TODO: obsolete this

        /// <summary>
        /// Return the point nearest a specific location given the X/Y pixel scaling information from a previous render.
        /// Will return <see cref="DataPoint.None"/> if the nearest point is greater than <paramref name="maxDistance"/> pixels away.
        /// </summary>
        DataPoint GetNearest(Coordinates location, RenderDetails renderInfo, float maxDistance = 15);

        public CoordinateRange GetLimitsX(); // TODO: struct

        public CoordinateRange GetLimitsY(); // TODO: struct

        AxisLimits GetLimits();
    }
}