﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public abstract class ArgbColormapBase : ColormapBase
{
    public abstract uint[] Argbs { get; }

    public override Color GetColor(double normalizedIntensity)
    {
        var argb = Argbs[(int)(normalizedIntensity * (Argbs.Length - 1))];
        return Color.FromArgb(argb);
    }
}
