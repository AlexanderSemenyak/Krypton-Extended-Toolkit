﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Heatmap : IPlottable, IHasColorAxis
    {
        public bool IsVisible { get; set; } = true;
        public IAxes Axes { get; set; } = new Axes();
        public IColormap Colormap { get; set; } = new Viridis();

        /// <summary>
        /// Indicates position of the data point relative to the rectangle used to represent it.
        /// An alignment of upper right means the rectangle will appear to the lower left of the point itself.
        /// </summary>
        public Alignment CellAlignment { get; set; } = Alignment.MiddleCenter;

        /// <summary>
        /// If defined, the this rectangle sets the axis boundaries of heatmap data.
        /// Note that the actual heatmap area is 1 cell larger than this rectangle.
        /// </summary>
        public CoordinateRect? Extent { get; set; }

        /// <summary>
        /// This variable controls whether row 0 of the 2D source array is the top or bottom of the heatmap.
        /// When set to false (default), row 0 is the top of the heatmap.
        /// When set to true, row 0 of the source data will be displayed at the bottom.
        /// </summary>
        public bool FlipVertically { get; set; } = false;

        /// <summary>
        /// If true, pixels in the final image will be interpolated to give the heatmap a smooth appearance.
        /// If false, the heatmap will appear as individual rectangles with sharp edges.
        /// </summary>
        public bool Smooth { get; set; } = false;

        /// <summary>
        /// Actual extent of the heatmap bitmap after alignment has been applied
        /// </summary>
        private CoordinateRect AlignedExtent
        {
            get
            {
                double x = CellWidth * CellAlignment.HorizontalFraction();
                double y = CellWidth * CellAlignment.VerticalFraction();
                Coordinates cellOffset = new(-x, -y);
                return ExtentOrDefault.WithTranslation(cellOffset);
            }
        }

        /// <summary>
        /// Extent used at render time.
        /// Supplies the user-provided extent if available, 
        /// otherwise a heatmap centered at the origin with cell size 1.
        /// </summary>
        private CoordinateRect ExtentOrDefault
        {
            get
            {
                if (Extent.HasValue)
                {
                    return Extent.Value;
                }

                return new CoordinateRect(
                    left: 0,
                    right: Intensities.GetLength(1),
                    bottom: 0,
                    top: Intensities.GetLength(0));
            }
        }

        /// <summary>
        /// Width of a single cell from the heatmap (in coordinate units)
        /// </summary>
        private double CellWidth => ExtentOrDefault.Width / Intensities.GetLength(1);

        /// <summary>
        /// Height of a single cell from the heatmap (in coordinate units)
        /// </summary>
        private double CellHeight => ExtentOrDefault.Height / Intensities.GetLength(0);

        /// <summary>
        /// This object holds data values for the heatmap.
        /// After editing contents users must call <see cref="Update"/> before changes
        /// appear on the heatmap.
        /// </summary>
        public readonly double[,] Intensities;

        /// <summary>
        /// Height of the heatmap data (rows)
        /// </summary>
        int Height => Intensities.GetLength(0);

        /// <summary>
        /// Width of the heatmap data (columns)
        /// </summary>
        int Width => Intensities.GetLength(1);

        /// <summary>
        /// Generated and stored when <see cref="Update"/> is called
        /// </summary>
        private SKBitmap? _bitmap = null;

        public Heatmap(double[,] intensities)
        {
            Intensities = intensities;
        }

        ~Heatmap()
        {
            _bitmap?.Dispose();
        }

        /// <summary>
        /// Return heatmap as an array of ARGB values,
        /// scaled according to the heatmap setting,
        /// and in the order necessary to create a bitmap.
        /// </summary>
        private uint[] GetArgbValues()
        {
            Range range = GetRange();
            uint[] argb = new uint[Intensities.Length];
            for (int y = 0; y < Height; y++)
            {
                int rowOffset = FlipVertically ? (Height - 1 - y) * Width : y * Width;
                for (int x = 0; x < Width; x++)
                {
                    argb[rowOffset + x] = Colormap.GetColor(Intensities[y, x], range).Argb;
                }
            }

            return argb;
        }

        public void Update()
        {
            uint[] argbs = GetArgbValues();
            _bitmap?.Dispose();
            _bitmap = Drawing.BitmapFromArgbs(argbs, Width, Height);
        }

        public AxisLimits GetAxisLimits()
        {
            return new(AlignedExtent);
        }

        /// <summary>
        /// Return the position in the array beneath the given point
        /// </summary>
        public (int x, int y) GetIndexes(Coordinates coordinates)
        {
            CoordinateRect rect = AlignedExtent;

            double distanceFromLeft = coordinates.X - rect.Left;
            int xIndex = (int)(distanceFromLeft / CellWidth);

            double distanceFromTop = rect.Top - coordinates.Y;
            int yIndex = (int)(distanceFromTop / CellHeight);

            return (xIndex, yIndex);
        }

        /// <summary>
        /// Return the value of the cell beneath the given point.
        /// Returns NaN if the point is outside the heatmap area.
        /// </summary>
        public double GetValue(Coordinates coordinates)
        {
            CoordinateRect rect = AlignedExtent;

            if (!rect.Contains(coordinates))
            {
                return double.NaN;
            }

            (int xIndex, int yIndex) = GetIndexes(coordinates);

            return Intensities[yIndex, xIndex];
        }

        public IEnumerable<LegendItem> LegendItems => Enumerable.Empty<LegendItem>();

        public Range GetRange() => Range.GetRange(Intensities);

        public void Render(RenderPack rp)
        {
            if (_bitmap is null)
            {
                Update(); // automatically generate the bitmap on first render if it was not generated manually
            }

            using SKPaint paint = new()
            {
                FilterQuality = Smooth ? SKFilterQuality.High : SKFilterQuality.None
            };

            SKRect rect = Axes.GetPixelRect(AlignedExtent).ToSkRect();

            rp.Canvas.DrawBitmap(_bitmap, rect, paint);
        }
    }
}