﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class LeftAxis : YAxisBase, IYAxis
    {
        public override Edge Edge { get; } = Edge.Left;

        public LeftAxis()
        {
            TickGenerator = new NumericAutomatic();
            Label.Rotation = -90;
        }
    }
}