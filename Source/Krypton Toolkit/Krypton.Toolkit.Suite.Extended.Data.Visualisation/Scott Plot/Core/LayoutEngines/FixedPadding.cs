﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Generate layouts where the data area has a fixed padding from the edge of the figure
    /// </summary>
    public class FixedPadding : LayoutEngineBase, ILayoutEngine
    {
        private PixelPadding Padding { get; }

        public FixedPadding(PixelPadding padding)
        {
            Padding = padding;
        }

        public Layout GetLayout(PixelRect figureRect, IEnumerable<IPanel> panels)
        {
            // must recalculate ticks before measuring panels

            panels.OfType<IXAxis>()
                .ToList()
                .ForEach(xAxis => xAxis.TickGenerator.Regenerate(xAxis.Range.ToCoordinateRange, xAxis.Edge, figureRect.Width));

            panels.OfType<IYAxis>()
                .ToList()
                .ForEach(yAxis => yAxis.TickGenerator.Regenerate(yAxis.Range.ToCoordinateRange, yAxis.Edge, figureRect.Height));

            Dictionary<IPanel, float> panelSizes = MeasurePanels(panels);
            Dictionary<IPanel, float> panelOffsets = GetPanelOffsets(panels, panelSizes);

            PixelRect dataRect = new(
                left: figureRect.Left + Padding.Left,
                right: figureRect.Left + figureRect.Width - Padding.Right,
                bottom: figureRect.Top + figureRect.Height - Padding.Bottom,
                top: figureRect.Top + Padding.Top);

            return new Layout(figureRect, dataRect, panelSizes, panelOffsets);
        }
    }
}