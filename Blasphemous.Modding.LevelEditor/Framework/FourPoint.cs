using System;
using System.Drawing;

namespace Blasphemous.Modding.LevelEditor.Framework;

public readonly record struct FourPoint
{
    public Vector TopLeft { get; init; }
    public Vector TopRight { get; init; }
    public Vector BottomLeft { get; init; }
    public Vector BottomRight { get; init; }

    public Vector Size => new(TopRight.X - TopLeft.X, BottomLeft.Y - TopLeft.Y, 0);

    public FourPoint Apply(Func<Vector, Vector> method)
    {
        return new FourPoint()
        {
            TopLeft = method(TopLeft),
            TopRight = method(TopRight),
            BottomLeft = method(BottomLeft),
            BottomRight = method(BottomRight)
        };
    }

    public bool IsPointInside(Vector point)
    {
        return point.X >= TopLeft.X && point.X <= TopRight.X
            && point.Y >= TopLeft.Y && point.Y <= BottomLeft.Y;
    }

    public Rectangle AsRectangle()
    {
        return new Rectangle(TopLeft, Size);
    }

    public Point[] AsArray()
    {
        return new Point[] { TopLeft, TopRight, BottomLeft };
    }
}
