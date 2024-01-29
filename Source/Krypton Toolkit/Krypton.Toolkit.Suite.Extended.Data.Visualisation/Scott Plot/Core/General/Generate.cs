﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This class contains methods which generate sample data for testing and demonstration purposes
    /// </summary>
    public static class Generate
    {
        public static RandomDataGenerator RandomData { get; } = new(0);

        #region numerical 1D

        /// <summary>
        /// Return an array of evenly-spaced numbers
        /// </summary>
        public static double[] Consecutive(int count = 51, double delta = 1, double first = 0)
        {
            var ys = new double[count];
            for (var i = 0; i < ys.Length; i++)
            {
                ys[i] = i * delta + first;
            }

            return ys;
        }

        /// <summary>
        /// Return an array of sine waves between -1 and 1.
        /// Values are multiplied by <paramref name="mult"/> then shifted by <paramref name="offset"/>.
        /// Phase shifts the sine wave horizontally between 0 and 2 Pi.
        /// </summary>
        public static double[] Sin(int count = 51, double mult = 1, double offset = 0, double oscillations = 1, double phase = 0)
        {
            var sinScale = 2 * Math.PI * oscillations / (count - 1);
            var ys = new double[count];
            for (var i = 0; i < ys.Length; i++)
            {
                ys[i] = Math.Sin(i * sinScale + phase * Math.PI * 2) * mult + offset;
            }

            return ys;
        }

        /// <summary>
        /// Return an array of cosine waves between -1 and 1.
        /// Values are multiplied by <paramref name="mult"/> then shifted by <paramref name="offset"/>.
        /// Phase shifts the sine wave horizontally between 0 and 2 Pi.
        /// </summary>
        public static double[] Cos(int count = 51, double mult = 1, double offset = 0, double oscillations = 1, double phase = 0)
        {
            var sinScale = 2 * Math.PI * oscillations / (count - 1);
            var ys = new double[count];
            for (var i = 0; i < ys.Length; i++)
            {
                ys[i] = Math.Cos(i * sinScale + phase * Math.PI * 2) * mult + offset;
            }

            return ys;
        }

        public static double[] NoisySin(Random rand, int count = 51, double noiseLevel = 1)
        {
            var data = Sin(count);
            for (var i = 0; i < data.Length; i++)
            {
                data[i] += rand.NextDouble() * noiseLevel;
            }
            return data;
        }

        public static double[] SquareWave(uint cycles = 20, uint pointsPerCycle = 1_000, double duty = .5, double low = 0, double high = 1)
        {
            if (duty is < 0 or > 1)
            {
                throw new ArgumentException($"{nameof(duty)} must be in the range [0, 1]");
            }

            var points = cycles * pointsPerCycle;
            var cyclePointsHigh = (uint)(pointsPerCycle * duty);
            var cyclePointsLow = pointsPerCycle - cyclePointsHigh;

            var values = new double[points];

            uint i = 0;

            for (var c = 0; c < cycles; c++)
            {
                for (var p = 0; p < cyclePointsLow; p++)
                {
                    values[i++] = low;
                }

                for (var p = 0; p < cyclePointsHigh; p++)
                {
                    values[i++] = high;
                }
            }

            return values;
        }

        public static double[] Zeros(int count)
        {
            return Repeating(count, 0);
        }

        public static double[] Ones(int count)
        {
            return Repeating(count, 1);
        }

        public static double[] Repeating(int count, double value)
        {
            var values = new double[count];

            for (var i = 0; i < values.Length; i++)
            {
                values[i] = value;
            }

            return values;
        }

        #endregion

        #region numerical 2D

        /// <summary>
        /// Generates a 2D array of numbers with constant spacing.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="spacing">The space between points.</param>
        /// <param name="offset">The first point.</param>
        /// <returns></returns>
        public static double[,] Consecutive2D(int rows, int columns, double spacing = 1, double offset = 0)
        {
            var data = new double[rows, columns];

            var count = offset;
            for (var y = 0; y < data.GetLength(0); y++)
            {
                for (var x = 0; x < data.GetLength(1); x++)
                {
                    data[y, x] = count;
                    count += spacing;
                }
            }

            return data;
        }

        /// <summary>
        /// Generates a 2D sine pattern.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="xPeriod">Frequency factor in x direction.</param>
        /// <param name="yPeriod">Frequency factor in y direction.</param>
        /// <param name="multiple">Intensity factor.</param>
        public static double[,] Sin2D(int width, int height, double xPeriod = .2, double yPeriod = .2, double multiple = 100)
        {
            var intensities = new double[height, width];

            for (var y = 0; y < height; y++)
            {
                var siny = Math.Cos(y * yPeriod) * multiple;
                for (var x = 0; x < width; x++)
                {
                    var sinx = Math.Sin(x * xPeriod) * multiple;
                    intensities[y, x] = sinx + siny;
                }
            }

            return intensities;
        }

        /// <summary>
        /// Generate a 2D array in a diagonal gradient pattern
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double[,] Ramp2D(int width, int height, double min = 0, double max = 1)
        {
            var intensities = new double[height, width];

            var span = max - min;

            for (var y = 0; y < height; y++)
            {
                var fracY = (double)y / height;
                var valY = fracY * span + min;

                for (var x = 0; x < width; x++)
                {
                    var fracX = (double)x / width;
                    var valX = fracX * span + min;

                    intensities[y, x] = (valX + valY) / 2;
                }
            }

            return intensities;
        }

        #endregion

        #region numerical random

        /// <summary>
        /// Return a series of values starting with <paramref name="offset"/> and
        /// each randomly deviating from the previous by at most <paramref name="mult"/>.
        /// </summary>
        public static double[] RandomWalk(int count, double mult = 1, double offset = 0)
        {
            return RandomData.RandomWalk(count, mult, offset);
        }

        public class RandomWalker(int seed = 0)
        {
            readonly RandomDataGenerator _gen = new(seed);
            double _lastValue = 0;

            public double GetNext()
            {
                var value = _gen.RandomWalk(1, offset: _lastValue)[0];
                _lastValue = value;
                return value;
            }

            public double[] GetNext(int count)
            {
                var values = _gen.RandomWalk(count, offset: _lastValue);
                _lastValue = values[values.Length - 1];
                return values;
            }
        }

        [Obsolete("use RandomSample()")]
        public static double[] Random(int count, double min = 0, double max = 1)
        {
            return RandomSample(count, min, max);
        }

        /// <summary>
        /// Return an array of <paramref name="count"/> random values 
        /// from <paramref name="min"/> to <paramref name="max"/>
        /// </summary>
        public static double[] RandomSample(int count, double min = 0, double max = 1)
        {
            return Enumerable.Range(0, count)
                .Select(_ => RandomData.RandomNumber(min, max))
                .ToArray();
        }

        public static double[] RandomNormal(int count, double mean = 0, double stdDev = 1)
        {
            return Enumerable.Range(0, count)
                .Select(_ => RandomData.RandomNormalNumber(mean, stdDev))
                .ToArray();
        }

        /// <summary>
        /// RandomSample integer between zero (inclusive) and <paramref name="max"/> (exclusive)
        /// </summary>
        public static int RandomInteger(int max)
        {
            return RandomData.RandomInteger(max);
        }

        /// <summary>
        /// RandomSample integer between <paramref name="min"/> (inclusive) and <paramref name="max"/> (exclusive)
        /// </summary>
        public static int RandomInteger(int min, int max)
        {
            return RandomData.RandomInteger(min, max);
        }

        /// <summary>
        /// RandomSample integers between zero (inclusive) and <paramref name="max"/> (exclusive)
        /// </summary>
        public static int[] RandomIntegers(int count, int max)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => RandomData.RandomInteger(max))
                .ToArray();
        }

        /// <summary>
        /// RandomSample integers between <paramref name="min"/> (inclusive) and <paramref name="max"/> (exclusive)
        /// </summary>
        public static int[] RandomIntegers(int count, int min, int max)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => RandomData.RandomInteger(min, max))
                .ToArray();
        }

        /// <summary>
        /// Return a copy of the given array with random values added to each point
        /// </summary>
        public static double[] AddNoise(double[] input, double magnitude = 1)
        {
            var output = new double[input.Length];
            Array.Copy(input, 0, output, 0, input.Length);
            AddNoiseInPlace(output, magnitude);
            return output;
        }

        /// <summary>
        /// Mutate the given array by adding a random value to each point
        /// </summary>
        public static void AddNoiseInPlace(double[] values, double magnitude = 1)
        {
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = values[i] + RandomData.RandomNumber(-magnitude / 2, magnitude / 2);
            }
        }

        #endregion

        #region text

        public static char RandomChar()
        {
            return (char)('A' + RandomInteger(26));
        }

        public static string RandomString(int length)
        {
            var chars = new char[length];

            for (var i = 0; i < chars.Length; i++)
            {
                chars[i] = RandomChar();
            }

            return new string(chars);
        }

        #endregion

        #region Axes

        public static Coordinates RandomCoordinates(double xMult = 1, double yMult = 1, double xOffset = 0, double yOffset = 0)
        {
            var x = RandomData.RandomNumber() * xMult + xOffset;
            var y = RandomData.RandomNumber() * yMult + yOffset;
            return new Coordinates(x, y);
        }

        public static Coordinates[] RandomCoordinates(int count, double xMult = 1, double yMult = 1, double xOffset = 0, double yOffset = 0)
        {
            Coordinates[] cs = new Coordinates[count];

            for (var i = 0; i < count; i++)
            {
                cs[i] = RandomCoordinates(xMult, yMult, xOffset, yOffset);
            }

            return cs;
        }

        public static Coordinates RandomLocation()
        {
            AxisLimits limits = new(0, 1, 0, 1);
            return RandomLocation(limits);
        }

        public static Coordinates RandomLocation(AxisLimits limits)
        {
            var x = RandomData.RandomNumber() * limits.HorizontalSpan + limits.Left;
            var y = RandomData.RandomNumber() * limits.VerticalSpan + limits.Bottom;
            return new Coordinates(x, y);
        }

        public static Coordinates[] RandomLocations(int count)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => RandomCoordinates())
                .ToArray();
        }

        public static Coordinates[] RandomLocations(int count, AxisLimits limits)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => RandomLocation(limits))
                .ToArray();
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Contains methods for generating DateTime sequences
        /// </summary>
        public static class DateTime
        {
            /// <summary>
            /// Date of the first ScottPlot commit
            /// </summary>
            public static readonly System.DateTime ExampleDate = new(2018, 01, 03);

            /// <summary>
            /// Evenly-spaced DateTimes
            /// </summary>
            public static System.DateTime[] Consecutive(int count, System.DateTime start, TimeSpan step)
            {
                var dt = start;
                var values = new System.DateTime[count];
                for (var i = 0; i < count; i++)
                {
                    values[i] = dt;
                    dt += step;
                }
                return values;
            }

            public static System.DateTime[] Weekdays(int count, System.DateTime start)
            {
                var dates = new System.DateTime[count];
                var i = 0;
                while (i < count)
                {
                    if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                    {
                        dates[i] = start;
                        i++;
                    }

                    start = start.AddDays(1);
                }
                return dates;
            }

            public static System.DateTime[] Weekdays(int count) => Weekdays(count, ExampleDate);

            public static System.DateTime[] Days(int count, System.DateTime start) => Consecutive(count, start, TimeSpan.FromDays(1));

            public static System.DateTime[] Days(int count) => Days(count, ExampleDate);

            public static System.DateTime[] Hours(int count, System.DateTime start) => Consecutive(count, start, TimeSpan.FromHours(1));

            public static System.DateTime[] Hours(int count) => Hours(count, ExampleDate);

            public static System.DateTime[] Minutes(int count, System.DateTime start) => Consecutive(count, start, TimeSpan.FromMinutes(1));

            public static System.DateTime[] Minutes(int count) => Hours(count, ExampleDate);

            public static System.DateTime[] Seconds(int count, System.DateTime start) => Consecutive(count, start, TimeSpan.FromSeconds(1));

            public static System.DateTime[] Seconds(int count) => Hours(count, ExampleDate);
        }

        #endregion

        #region Finance

        public static List<Ohlc> RandomOhlCs(int count)
        {
            return RandomData.RandomOhlCs(count);
        }

        #endregion

        #region Plot Items

        public static Box RandomBox(double position)
        {
            var n = 50;
            var mean = RandomData.RandomNumber(3);
            var stdDev = RandomData.RandomNumber(3);

            var values = RandomNormal(n, mean, stdDev);
            Array.Sort(values);
            var min = values[0];
            var q1 = values[n / 4];
            var median = values[n / 2];
            var q3 = values[3 * n / 4];
            var max = values[n - 1];

            return new Box
            {
                Position = position,
                WhiskerMin = min,
                BoxMin = q1,
                BoxMiddle = median,
                BoxMax = q3,
                WhiskerMax = max,
            };
        }

        public static Color RandomColor()
        {
            var r = RandomData.RandomByte();
            var g = RandomData.RandomByte();
            var b = RandomData.RandomByte();
            return new Color(r, g, b);
        }

        /// <summary>
        /// Generate a dark color by defining the maximum value to use for R, G, and B
        /// </summary>
        public static Color RandomColor(byte max)
        {
            var r = (byte)RandomData.RandomInteger(max);
            var g = (byte)RandomData.RandomInteger(max);
            var b = (byte)RandomData.RandomInteger(max);
            return new Color(r, g, b);
        }

        public static Color RandomColor(IColormap colormap)
        {
            return colormap.GetColor(RandomData.RandomNumber());
        }

        public static Color[] RandomColors(int count, IColormap colormap)
        {
            return RandomSample(count).Select(colormap.GetColor).ToArray();
        }

        public static MarkerShape RandomMarkerShape()
        {
            MarkerShape[] markerShapes = Enum
                .GetValues(typeof(MarkerShape))
                .Cast<MarkerShape>()
                .ToArray();

            var i = RandomInteger(markerShapes.Length);
            return markerShapes[i];
        }

        public static CoordinateLine RandomLine()
        {
            return new CoordinateLine(RandomLocation(), RandomLocation());
        }

        public static LinePattern RandomLinePattern()
        {
            LinePattern[] linePatterns = Enum
                .GetValues(typeof(LinePattern))
                .Cast<LinePattern>()
                .ToArray();

            var i = RandomInteger(linePatterns.Length);
            return linePatterns[i];
        }

        #endregion
    }
}