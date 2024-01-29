﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class CacheScatterLimitsDecorator : IScatterSource
    {
        private readonly IScatterSource _source;

        private AxisLimits? _axisLimits = null;
        private CoordinateRange _limitsX = CoordinateRange.NotSet;
        private CoordinateRange _limitsY = CoordinateRange.NotSet;

        public CacheScatterLimitsDecorator(IScatterSource source)
        {
            _source = source;
        }

        public AxisLimits GetLimits()
        {
            _axisLimits ??= _source.GetLimits();

            return _axisLimits.Value;
        }

        public CoordinateRange GetLimitsX()
        {
            if (_limitsX == CoordinateRange.NotSet)
            {
                _limitsX = _source.GetLimitsX();
            }

            return _limitsX;
        }

        public CoordinateRange GetLimitsY()
        {
            if (_limitsY == CoordinateRange.NotSet)
            {
                _limitsY = _source.GetLimitsY();
            }

            return _limitsY;
        }

        public DataPoint GetNearest(Coordinates mouseLocation, RenderDetails renderInfo, float maxDistance = 15)
        {
            return _source.GetNearest(mouseLocation, renderInfo, maxDistance);
        }

        public IReadOnlyList<Coordinates> GetScatterPoints()
        {
            return _source.GetScatterPoints();
        }
    }
}