
namespace Blasphemous.Modding.LevelEditor.Components;

public class Thing
{
    public string Name { get; set; } = "New object";

    public Transform Transform { get; }

    public Sprite Sprite { get; }

    public Collider Collider { get; }

    public Thing()
    {
        Transform = new Transform(this);
        Sprite = new Sprite(this);
        Collider = new Collider(this);
    }
}
