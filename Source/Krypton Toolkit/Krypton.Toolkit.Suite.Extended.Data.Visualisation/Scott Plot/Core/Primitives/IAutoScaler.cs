﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Contains logic for determining new axis limits when Autoscale() is called
    /// </summary>
    public interface IAutoScaler
    {
        /// <summary>
        /// Return the recommended axis limits for the plottables that use the given axes
        /// </summary>
        AxisLimits GetAxisLimits(Plot plot, IXAxis xAxis, IYAxis yAxis);

        /// <summary>
        /// Autoscale every unset axis used by plottables.
        /// </summary>
        public void AutoScaleAll(IEnumerable<IPlottable> plottables);

        // TODO: GetRecommendedAxisLimits() should return a dictionary of limits by axis,
        // then both functions can be collapsed into one.

        public bool InvertedX { get; set; }
        public bool InvertedY { get; set; }
    }
}