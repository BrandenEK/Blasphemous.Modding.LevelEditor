using System.Drawing;

namespace Blasphemous.Modding.LevelEditor.Framework;

/// <summary>
/// Serializable representation of a Vector3
/// </summary>
public readonly record struct Vector
{
    /// <summary> The X coordinate </summary>
    public float X { get; }
    /// <summary> The Y coordinate </summary>
    public float Y { get; }
    /// <summary> The Z coordinate </summary>
    public float Z { get; }

    /// <summary>
    /// Creates a new Vector with the specified properties
    /// </summary>
    public Vector(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Creates a new Vector with the specified properties
    /// </summary>
    //public Vector(float x, float y)
    //{
    //    X = x;
    //    Y = y;
    //    Z = 0;
    //}

    /// <summary>
    /// Formats the vector
    /// </summary>
    public override string ToString() => $"({X}, {Y}, {Z})";

    /// <summary> (0, 0, 0) </summary>
    public static Vector Zero => new(0, 0, 0);
    /// <summary> (1, 1, 1) </summary>
    public static Vector One => new(1, 1, 1);
    /// <summary> (-1, 0, 0) </summary>
    public static Vector Left => new(-1, 0, 0);
    /// <summary> (1, 0, 0) </summary>
    public static Vector Right => new(1, 0, 0);
    /// <summary> (0, -1, 0) </summary>
    public static Vector Down => new(0, -1, 0);
    /// <summary> (0, 1, 0) </summary>
    public static Vector Up => new(0, 1, 0);
    /// <summary> (0, 0, -1) </summary>
    public static Vector Back => new(0, 0, 1);
    /// <summary> (0, 0, 1) </summary>
    public static Vector Forward => new(0, 0, 1);

    /// <summary>
    /// Adds the elements of two vectors
    /// </summary>
    public static Vector operator +(Vector v1, Vector v2) =>
        new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

    /// <summary>
    /// Subtracts the elements of two vectors
    /// </summary>
    public static Vector operator -(Vector v1, Vector v2) =>
        new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

    /// <summary>
    /// Multiplies the elements of two vectors
    /// </summary>
    public static Vector operator *(Vector v1, Vector v2) =>
        new(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);

    /// <summary>
    /// Scales the vector
    /// </summary>
    public static Vector operator *(Vector v, float scalar)
        => new(v.X * scalar, v.Y * scalar, v.Z * scalar);

    /// <summary>
    /// Converts to a Point
    /// </summary>
    public static implicit operator Point(Vector v) =>
        new((int)v.X, (int)v.Y);

    /// <summary>
    /// Converts to a Size
    /// </summary>
    public static implicit operator Size(Vector v) =>
        new((int)v.X, (int)v.Y);

    /// <summary>
    /// Converts to a SerializeableVector
    /// </summary>
    public static implicit operator Vector(Point p) =>
        new(p.X, p.Y, 0);
}
