using System;
using System.Drawing;

namespace ConsoleToolkit.vendor
{
    internal class ClosestConsoleColor
    {
        // Calculates the closest ConsoleColor to the specified hex color
        public ConsoleColor Calculate(string hexColor)
        {
            Color color = ColorTranslator.FromHtml(hexColor);
            ConsoleColor ret = 0;
            double rr = color.R, gg = color.G, bb = color.B, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }
    }
}
