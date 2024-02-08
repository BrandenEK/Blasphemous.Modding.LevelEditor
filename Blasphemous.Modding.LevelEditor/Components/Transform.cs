using Blasphemous.Modding.LevelEditor.Framework;

namespace Blasphemous.Modding.LevelEditor.Components;

public class Transform : Component
{
    public Transform(Thing owner) : base(owner) { }

    public Vector Position { get; set; } = Vector.Zero;

    public Vector Rotation { get; set; } = Vector.Zero;

    public Vector Scale { get; set; } = Vector.One;

    public void Refresh()
    {
        Owner.Sprite.Refresh();
        Owner.Collider.Refresh();
    }
}
