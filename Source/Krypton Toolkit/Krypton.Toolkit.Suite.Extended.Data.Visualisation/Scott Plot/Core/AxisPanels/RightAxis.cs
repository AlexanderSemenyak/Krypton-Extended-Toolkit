﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RightAxis : YAxisBase, IYAxis
    {
        public override Edge Edge { get; } = Edge.Right;

        public RightAxis()
        {
            TickGenerator = new NumericAutomatic();
            Label.Rotation = 90;
        }
    }
}