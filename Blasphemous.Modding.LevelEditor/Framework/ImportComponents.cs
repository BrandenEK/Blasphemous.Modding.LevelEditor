namespace Blasphemous.Modding.LevelEditor.Framework;

public class ThingImport
{
    public string name;
    public TransformImport transform;
    public SpriteImport sprite;
    public ColliderImport? collider;

    public ThingImport(string name, TransformImport transform, SpriteImport sprite, ColliderImport collider)
    {
        this.name = name;
        this.transform = transform;
        this.sprite = sprite;
        this.collider = collider;
    }
}

public class TransformImport
{
    public Vector position;
    public Vector rotation;
    public Vector scale;

    public TransformImport(Vector position, Vector rotation, Vector scale)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
}

public class SpriteImport
{
    public string image;
    public int layer;
    public int order;
    public bool flip;
    public Vector pivot;

    public SpriteImport(string image, int layer, int order, bool flip, Vector pivot)
    {
        this.image = image;
        this.layer = layer;
        this.order = order;
        this.flip = flip;
        this.pivot = pivot;
    }
}

public class ColliderImport
{
    public Vector offset;
    public Vector size;
    public bool trigger;

    public ColliderImport(Vector offset, Vector size, bool trigger)
    {
        this.offset = offset;
        this.size = size;
        this.trigger = trigger;
    }
}
