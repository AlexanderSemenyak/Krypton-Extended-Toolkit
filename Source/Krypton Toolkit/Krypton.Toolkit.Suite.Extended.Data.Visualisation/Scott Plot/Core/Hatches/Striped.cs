﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Striped : IHatch
    {
        public Striped(StripeDirection stripeDirection = StripeDirection.DiagonalUp)
        {
            StripeDirection = stripeDirection;
        }

        // This is implemented as a transformation of the shader, so we don't need to invalidate the bitmap in the setter
        public StripeDirection StripeDirection { get; set; }
        static Striped()
        {
            _bmp = CreateBitmap();
        }
        private static readonly SKBitmap _bmp;
        private static SKBitmap CreateBitmap()
        {
            var bitmap = new SKBitmap(20, 50);

            using var paint = new SKPaint() { Color = Colors.White.ToSkColor() };
            using var path = new SKPath();
            using var canvas = new SKCanvas(bitmap);

            canvas.Clear(Colors.Black.ToSkColor());
            canvas.DrawRect(new SKRect(0, 0, 20, 20), paint);

            return bitmap;
        }

        public SKShader GetShader(Color backgroundColor, Color hatchColor)
        {
            var rotationMatrix = StripeDirection switch
            {
                StripeDirection.DiagonalUp => SKMatrix.CreateRotationDegrees(-45),
                StripeDirection.DiagonalDown => SKMatrix.CreateRotationDegrees(45),
                StripeDirection.Horizontal => SKMatrix.Identity,
                StripeDirection.Vertical => SKMatrix.CreateRotationDegrees(90),
                _ => throw new NotImplementedException(nameof(StripeDirection))
            };

            return SKShader.CreateBitmap(
                _bmp,
                SKShaderTileMode.Repeat,
                SKShaderTileMode.Repeat,
                SKMatrix.CreateScale(0.1f, 0.15f)
                    .PostConcat(rotationMatrix))
                    .WithColorFilter(Drawing.GetMaskColorFilter(hatchColor, backgroundColor));
        }
    }
}