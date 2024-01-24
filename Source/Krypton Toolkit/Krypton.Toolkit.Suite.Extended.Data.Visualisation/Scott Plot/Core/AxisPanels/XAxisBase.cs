﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public abstract class XAxisBase : AxisBase, IAxis
    {
        public double Width => Range.Span;

        public XAxisBase()
        {
            Label.Rotation = 0;
        }

        public float Measure()
        {
            if (!IsVisible)
            {
                return 0;
            }

            var largestTickSize = MeasureTicks();
            float largestTickLabelSize = Label.Measure().Height;
            float spaceBetweenTicksAndAxisLabel = 15;
            return largestTickSize + largestTickLabelSize + spaceBetweenTicksAndAxisLabel;
        }

        private float MeasureTicks()
        {
            using SKPaint paint = new();
            TickLabelStyle.ApplyToPaint(paint);

            float largestTickHeight = 0;

            foreach (Tick tick in TickGenerator.Ticks)
            {
                PixelSize tickLabelSize = Drawing.MeasureString(tick.Label, paint);
                largestTickHeight = Math.Max(largestTickHeight, tickLabelSize.Height + 10);
            }

            return largestTickHeight;
        }

        public float GetPixel(double position, PixelRect dataArea)
        {
            var pxPerUnit = dataArea.Width / Width;
            var unitsFromLeftEdge = position - Min;
            var pxFromEdge = (float)(unitsFromLeftEdge * pxPerUnit);
            return dataArea.Left + pxFromEdge;
        }

        public double GetCoordinate(float pixel, PixelRect dataArea)
        {
            var pxPerUnit = dataArea.Width / Width;
            var pxFromLeftEdge = pixel - dataArea.Left;
            var unitsFromEdge = pxFromLeftEdge / pxPerUnit;
            return Min + unitsFromEdge;
        }

        private PixelRect GetPanelRectangleBottom(PixelRect dataRect, float size, float offset)
        {
            return new PixelRect(
                left: dataRect.Left,
                right: dataRect.Right,
                bottom: dataRect.Bottom + offset + size,
                top: dataRect.Bottom + offset);
        }

        private PixelRect GetPanelRectangleTop(PixelRect dataRect, float size, float offset)
        {
            return new PixelRect(
                left: dataRect.Left,
                right: dataRect.Right,
                bottom: dataRect.Top - offset,
                top: dataRect.Top - offset - size);
        }

        public PixelRect GetPanelRect(PixelRect dataRect, float size, float offset)
        {
            return Edge == Edge.Bottom
                ? GetPanelRectangleBottom(dataRect, size, offset)
                : GetPanelRectangleTop(dataRect, size, offset);
        }

        public void Render(RenderPack rp, float size, float offset)
        {
            if (!IsVisible)
            {
                return;
            }

            PixelRect panelRect = GetPanelRect(rp.DataRect, size, offset);

            float textDistanceFromEdge = 10;
            Pixel labelPoint = new(panelRect.HorizontalCenter, panelRect.Bottom - textDistanceFromEdge);

            if (ShowDebugInformation)
            {
                Drawing.DrawDebugRectangle(rp.Canvas, panelRect, labelPoint, Label.ForeColor);
            }

            Label.Alignment = Alignment.LowerCenter;
            Label.Render(rp.Canvas, labelPoint);

            DrawTicks(rp, TickLabelStyle, panelRect, TickGenerator.Ticks, this, MajorTickStyle, MinorTickStyle);
            DrawFrame(rp, panelRect, Edge, FrameLineStyle);
        }

        public double GetPixelDistance(double distance, PixelRect dataArea)
        {
            return distance * dataArea.Width / Width;
        }

        public double GetCoordinateDistance(float distance, PixelRect dataArea)
        {
            return distance / (dataArea.Width / Width);
        }
    }
}