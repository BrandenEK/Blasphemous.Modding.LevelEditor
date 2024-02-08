using Blasphemous.Modding.LevelEditor.Framework;

namespace Blasphemous.Modding.LevelEditor.Components;

public class Collider : Component
{
    public Collider(Thing owner) : base(owner) { }

    public Vector Offset { get; set; } = Vector.Zero;

    public Vector Size { get; set; } = Vector.One;

    public bool IsTrigger { get; set; } = false;

    public void Refresh()
    {

    }
}
