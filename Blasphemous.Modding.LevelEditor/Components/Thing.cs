using Blasphemous.Modding.LevelEditor.Framework;
using Blasphemous.Modding.LevelEditor.Import;

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

    public static Thing Import(ThingImport import)
    {
        Thing obj = new();
        obj.Name = import.name;

        obj.Transform.Position = import.transform.position;
        obj.Transform.Rotation = import.transform.rotation;
        obj.Transform.Scale = import.transform.scale;

        obj.Sprite.Image = TextureImporter.Load(import.sprite.image);
        obj.Sprite.SortingLayer = import.sprite.layer;
        obj.Sprite.SortingOrder = import.sprite.order;
        obj.Sprite.HorizontalFlip = import.sprite.flip;
        obj.Sprite.Pivot = import.sprite.pivot;

        // Collider

        return obj;
    }
}
