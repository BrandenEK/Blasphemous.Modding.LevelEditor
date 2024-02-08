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

    public bool DrawImage(Graphics g, Vector origin, out Vector tl, out Vector br)
    {
        if (Image == null)
        {
            tl = Vector.Zero;
            br = Vector.Zero;
            return false;
        }

        // Draw image
        FourPoint fp = GetImageRect(origin);
        g.DrawImage(Image, new Point[] { fp.TopLeft, fp.TopRight, fp.BottomLeft });

        tl = fp.TopLeft;
        br = fp.BottomRight;
        return true;
    }

    public void DrawOutline(Graphics g, Vector origin)
    {
        if (Image == null)
            return;

        Pen p = new(Color.Cyan, 1f);
        FourPoint fp = GetImageRect(origin);
        Rectangle r = new(fp.TopLeft, fp.Size);

        g.DrawRectangle(p, r);
    }

    public FourPoint GetImageRect(Vector origin)
    {
        Vector position = _owner.Transform.Position;
        Vector rotation = _owner.Transform.Rotation;
        Vector scale = _owner.Transform.Scale;

        // Get center and size in pixels
        Vector pixelCenter = position * Editor.PIXELS_PER_UNIT;
        Vector pixelSize = new Vector(Image!.Width, Image.Height, 0) * scale;

        // Calculate corner points
        FourPoint fp = new()
        {
            TopLeft = new(pixelCenter.X - pixelSize.X / 2, pixelCenter.Y + pixelSize.Y / 2, 0),
            TopRight = new(pixelCenter.X + pixelSize.X / 2, pixelCenter.Y + pixelSize.Y / 2, 0),
            BottomLeft = new(pixelCenter.X - pixelSize.X / 2, pixelCenter.Y - pixelSize.Y / 2, 0),
            BottomRight = new(pixelCenter.X + pixelSize.X / 2, pixelCenter.Y - pixelSize.Y / 2, 0)
        };

        // Rotate corner points
        fp.Apply(v => RotateAround(v, pixelCenter, rotation.Z));

        // Reflect corner points
        if (HorizontalFlip)
        {
            (fp.TopLeft, fp.TopRight) = (fp.TopRight, fp.TopLeft);
            (fp.BottomLeft, fp.BottomRight) = (fp.BottomRight, fp.BottomLeft);
        }

        // Translate corner points by pivot offset
        Vector pixelOffset = (new Vector(0.5f, 0.5f, 0) - Pivot) * pixelSize;
        fp.Apply(v => v + pixelOffset);

        // Flip corner points across y axis
        Vector pixelMirror = new(1, -1, 1);
        fp.Apply(v => v * pixelMirror + origin);

        return fp;
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
}
