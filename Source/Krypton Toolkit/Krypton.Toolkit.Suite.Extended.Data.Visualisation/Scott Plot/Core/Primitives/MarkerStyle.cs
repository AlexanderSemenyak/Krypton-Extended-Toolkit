﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This configuration object (reference type) permanently lives inside objects which require styling.
    /// It is recommended to use this object as an init-only property.
    /// </summary>
    public class MarkerStyle
    {
        public bool IsVisible { get; set; }

        public MarkerShape Shape { get; set; }

        /// <summary>
        /// Diameter of the marker (in pixels)
        /// </summary>
        public float Size { get; set; }

        public FillStyle Fill { get; set; } = new() { Color = Colors.Gray };

        public LineStyle Outline { get; set; } = new() { Width = 0 };

        public MarkerStyle() : this(MarkerShape.FilledCircle, 5, Colors.Gray)
        {
        }

        public MarkerStyle(MarkerShape shape, float size) : this(shape, size, Colors.Gray)
        {
        }

        public MarkerStyle(MarkerShape shape, float size, Color color)
        {
            Shape = shape;
            IsVisible = shape != MarkerShape.None;

            Outline.Color = color;
            if (shape.IsOutlined())
            {
                Fill.Color = Colors.Transparent;
                Outline.Width = 2;
            }
            else
            {
                Fill.Color = color;
            }

            Size = size;
        }

        public static MarkerStyle Default => new(MarkerShape.FilledCircle, 5);

        public static MarkerStyle None => new(MarkerShape.None, 0);
    }
}