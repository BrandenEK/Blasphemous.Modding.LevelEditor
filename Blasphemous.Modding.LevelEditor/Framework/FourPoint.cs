using System;
using System.Drawing;

namespace Blasphemous.Modding.LevelEditor.Framework;

public class FourPoint
{
    public Vector TopLeft { get; set; }
    public Vector TopRight { get; set; }
    public Vector BottomLeft { get; set; }
    public Vector BottomRight { get; set; }

    public Vector Size => new(TopRight.X - TopLeft.X, BottomLeft.Y - TopLeft.Y, 0);
    public Rectangle Rect => new(TopLeft, Size);

    public void Apply(Func<Vector, Vector> method)
    {
        TopLeft = method(TopLeft);
        TopRight = method(TopRight);
        BottomLeft = method(BottomLeft);
        BottomRight = method(BottomRight);
    }

    public bool IsPointInside(Vector point)
    {
        return point.X >= TopLeft.X && point.X <= TopRight.X
            && point.Y >= TopLeft.Y && point.Y <= BottomLeft.Y;
    }
}
