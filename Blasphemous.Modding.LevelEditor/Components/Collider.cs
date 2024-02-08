using Blasphemous.Modding.LevelEditor.Framework;
using System.Drawing;

namespace Blasphemous.Modding.LevelEditor.Components;

public class Collider
{
    private readonly Thing _owner;

    public Collider(Thing owner)
    {
        _owner = owner;
    }

    public Vector Offset { get; set; } = Vector.Zero;

    public Vector Size { get; set; } = Vector.One;

    public bool IsTrigger { get; set; } = false;

    public void Refresh()
    {

    }

    private void DrawImage(Graphics g)
    {

    }
}
