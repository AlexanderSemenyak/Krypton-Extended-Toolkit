﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Eks : IMarker
    {
        public void Render(SKCanvas canvas, SKPaint paint, Pixel center, float size, FillStyle fill, LineStyle outline)
        {
            float offset = size / 2;

            var path = new SKPath();
            path.MoveTo(center.X + offset, center.Y + offset);
            path.LineTo(center.X - offset, center.Y - offset);
            path.MoveTo(center.X - offset, center.Y + offset);
            path.LineTo(center.X + offset, center.Y - offset);

            outline.ApplyToPaint(paint);
            canvas.DrawPath(path, paint);
        }
    }
}