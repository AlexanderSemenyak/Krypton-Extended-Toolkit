﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class DataStreamerSource
    {
        /// <summary>
        /// Fixed-length array used as a circular buffer to shift data in at the position defined by <see cref="NextIndex"/>.
        /// Values in this array should not be modified externally if <see cref="ManageAxisLimits"/> is enabled.
        /// </summary>
        public double[] Data { get; }

        /// <summary>
        /// Index in <see cref="Data"/> where the next point will be added
        /// </summary>
        public int NextIndex { get; private set; } = 0;

        /// <summary>
        /// The fied number of visible data points to display
        /// </summary>
        public int Length => Data.Length;

        /// <summary>
        /// The total number of data points added
        /// </summary>
        public int CountTotal { get; private set; } = 0;

        /// <summary>
        /// Total of data points added the last time this plottable was rendered.
        /// This can be compared with <see cref="CountTotal"/> to determine if a new render is required.
        /// </summary>
        public int CountTotalOnLastRender { get; set; } = -1;

        /// <summary>
        /// Minimum value of all known data (not just the data in view)
        /// </summary>
        public double DataMin { get; private set; } = double.PositiveInfinity;

        /// <summary>
        /// Maximum value of all known data (not just the data in view)
        /// </summary>
        public double DataMax { get; private set; } = double.NegativeInfinity;

        public double OffsetX { get; set; } = 0;

        public double OffsetY { get; set; } = 0;

        public double SamplePeriod { get; set; } = 1;

        public DataStreamerSource(double[] data)
        {
            Data = data;
        }

        /// <summary>
        /// Shift in a new Y value
        /// </summary>
        public void Add(double value)
        {
            Data[NextIndex] = value;
            NextIndex += 1;

            if (NextIndex >= Data.Length)
            {
                NextIndex = 0;
            }

            DataMin = Math.Min(value, DataMin);
            DataMax = Math.Max(value, DataMax);

            CountTotal += 1;
        }

        /// <summary>
        /// Shift in a collection of new Y values
        /// </summary>
        public void AddRange(IEnumerable<double> values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        /// <summary>
        /// Clear the buffer by setting all Y points to the given value
        /// </summary>
        public void Clear(double value = 0)
        {
            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = 0;
            }

            DataMin = value;
            DataMax = value;

            NextIndex = 0;
            CountTotal = 0;
        }

        public AxisLimits GetAxisLimits()
        {
            if (double.IsInfinity(DataMin) || double.IsInfinity(DataMax))
            {
                return AxisLimits.NoLimits;
            }

            var xMin = OffsetX;
            var xMax = xMin + Data.Length * SamplePeriod;
            return new AxisLimits(xMin, xMax, DataMin, DataMax);
        }
    }
}