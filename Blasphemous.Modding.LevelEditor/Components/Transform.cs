using Blasphemous.Modding.LevelEditor.Framework;

namespace Blasphemous.Modding.LevelEditor.Components;

public class Transform
{
    private readonly Thing _owner;

    public Vector Position { get; set; } = Vector.Zero;

    public Vector Rotation { get; set; } = Vector.Zero;

    public Vector Scale { get; set; } = Vector.One;

    public Transform(Thing owner)
    {
        _owner = owner;
    }

    public void Refresh()
    {
        _owner.Sprite.Refresh();
        _owner.Collider.Refresh();
    }
}
