﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class DataStreamer : IPlottable, IManagesAxisLimits
    {
        public bool IsVisible { get; set; } = true;
        public IAxes Axes { get; set; } = ScottPlot.Axes.Default;
        public IEnumerable<LegendItem> LegendItems => LegendItem.None;

        public readonly LineStyle LineStyle = new();

        public Color Color
        {
            get => LineStyle.Color;
            set => LineStyle.Color = value;
        }

        public DataStreamerSource Data { get; set; }

        public double Period
        {
            get => Data.SamplePeriod;
            set => Data.SamplePeriod = value;
        }

        /// <summary>
        /// Returns true if data has been added since the last render
        /// </summary>
        public bool HasNewData => Data.CountTotal != Data.CountTotalOnLastRender;

        /// <summary>
        /// If enabled, axis limits will be adjusted automatically if new data runs off the screen.
        /// </summary>
        public bool ManageAxisLimits { get; set; } = true;

        /// <summary>
        /// Contains logic for automatically adjusting axis limits if new data runs off the screen.
        /// Only used if <see cref="ManageAxisLimits"/> is true.
        /// </summary>
        private IAxisManager AxisManager { get; set; } = new FixedWidth();

        /// <summary>
        /// Used to obtain the current axis limits so <see cref="AxisManager"/> can adjust them if needed.
        /// </summary>
        private readonly Plot _plot;

        /// <summary>
        /// Logic for displaying the fixed-length Y values in <see cref="Data"/>
        /// </summary>
        public IDataStreamerView Renderer { get; set; }

        public DataStreamer(Plot plot, double[] data)
        {
            _plot = plot;
            Data = new DataStreamerSource(data);
            Renderer = new Wipe(this, true);
        }

        /// <summary>
        /// Shift in a new Y value
        /// </summary>
        public void Add(double value)
        {
            Data.Add(value);
        }

        /// <summary>
        /// Shift in a collection of new Y values
        /// </summary>
        public void AddRange(IEnumerable<double> values)
        {
            Data.AddRange(values);
        }

        /// <summary>
        /// Clear the buffer by setting all Y points to the given value
        /// </summary>
        public void Clear(double value = 0)
        {
            Data.Clear(value);
        }

        /// <summary>
        /// Display the data using a view where new data overlapps old data from left to right.
        /// </summary>
        public void ViewWipeRight()
        {
            Renderer = new Wipe(this, true);
        }

        /// <summary>
        /// Display the data using a view where new data overlapps old data from right to left.
        /// </summary>
        public void ViewWipeLeft()
        {
            Renderer = new Wipe(this, false);
        }

        /// <summary>
        /// Display the data using a view that continuously shifts data to the left, placing the newest data on the right.
        /// </summary>
        public void ViewScrollLeft()
        {
            Renderer = new Scroll(this, true);
        }

        /// <summary>
        /// Display the data using a view that continuously shifts data to the right, placing the newest data on the left.
        /// </summary>
        public void ViewScrollRight()
        {
            Renderer = new Scroll(this, false);
        }

        /*
        // TODO: slide axes
        /// <summary>
        /// Display the data using a view that continuously shifts data to the left,
        /// placing the newest data on the right, and sliding the horizontal axis
        /// to track the latest data coming in.
        /// </summary>
        public void ViewSlideLeft()
        {
            Renderer = new DataViews.Scroll(this, true);
        }
        */

        /// <summary>
        /// Display the data using a custom rendering function
        /// </summary>
        public void ViewCustom(IDataStreamerView view)
        {
            Renderer = view;
        }

        public AxisLimits GetAxisLimits()
        {
            return Data.GetAxisLimits();
        }

        public void UpdateAxisLimits(Plot plot, bool force = false)
        {
            AxisLimits limits = _plot.Axes.GetLimits(Axes);
            AxisLimits dataLimits = Data.GetAxisLimits();
            AxisLimits newLimits = AxisManager.GetAxisLimits(limits, dataLimits);
            _plot.Axes.SetLimits(newLimits);
        }

        public void Render(RenderPack rp)
        {
            Renderer.Render(rp);
            Data.CountTotalOnLastRender = Data.CountTotal;
        }
    }
}