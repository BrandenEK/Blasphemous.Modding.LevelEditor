using Blasphemous.Modding.LevelEditor.Framework;
using System;
using System.Drawing;

namespace Blasphemous.Modding.LevelEditor.Components;

public class Sprite
{
    private readonly Thing _owner;

    public Bitmap? Image { get; set; } = null;

    public int SortingLayer { get; set; } = 0;

    public int SortingOrder { get; set; } = 0;

    public bool HorizontalFlip { get; set; } = false;

    public Vector Pivot { get; set; } = new Vector(0.5f, 0.5f, 0);

    public Sprite(Thing owner)
    {
        _owner = owner;
    }

    public void Refresh()
    {

    }

    public void DrawOutline(Graphics g, Vector origin)
    {
        Pen p = new(Color.Cyan, 1f);

        g.DrawRectangle(p, Points.AsRectangle());
    }

    private static float DegreeToRadians(float degrees) => degrees * MathF.PI / 180f;

    private static Vector RotateAround(Vector point, Vector pivot, float degrees)
    {
        float radians = DegreeToRadians(degrees);
        float sin = MathF.Sin(radians);
        float cos = MathF.Cos(radians);

        float x = cos * (point.X - pivot.X) - sin * (point.Y - pivot.Y) + pivot.X;
        float y = sin * (point.X - pivot.X) + cos * (point.Y - pivot.Y) + pivot.Y;

        return new Vector(x, y, 0);
    }

    private bool _needsUpdate = true;

    private FourPoint m_points;
    public FourPoint Points
    {
        get
        {
            if (!_needsUpdate)
                return m_points;

            Vector position = _owner.Transform.Position;
            Vector rotation = _owner.Transform.Rotation;
            Vector scale = _owner.Transform.Scale;

            // Get center and size in pixels
            Vector pixelCenter = position * Editor.PIXELS_PER_UNIT;
            Vector pixelSize = new Vector(Image?.Width ?? 1, Image?.Height ?? 1, 0) * scale;

            // Calculate corner points
            FourPoint points = new()
            {
                TopLeft = new(pixelCenter.X - pixelSize.X / 2, pixelCenter.Y + pixelSize.Y / 2, 0),
                TopRight = new(pixelCenter.X + pixelSize.X / 2, pixelCenter.Y + pixelSize.Y / 2, 0),
                BottomLeft = new(pixelCenter.X - pixelSize.X / 2, pixelCenter.Y - pixelSize.Y / 2, 0),
                BottomRight = new(pixelCenter.X + pixelSize.X / 2, pixelCenter.Y - pixelSize.Y / 2, 0)
            };

            // Rotate corner points
            points = points.Apply(v => RotateAround(v, pixelCenter, rotation.Z));

            // Reflect corner points
            if (HorizontalFlip)
            {
                points = new FourPoint()
                {
                    TopLeft = points.TopRight,
                    TopRight = points.TopLeft,
                    BottomLeft = points.BottomRight,
                    BottomRight = points.BottomLeft
                };
            }

            // Translate corner points by pivot offset
            Vector pixelOffset = (new Vector(0.5f, 0.5f, 0) - Pivot) * pixelSize;
            points = points.Apply(v => v + pixelOffset);

            _needsUpdate = false;
            return m_points = points;
        }
    }
}
