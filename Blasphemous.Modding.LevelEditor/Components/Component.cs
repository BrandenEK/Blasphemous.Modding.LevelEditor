
namespace Blasphemous.Modding.LevelEditor.Components;

public class Component
{
    public Thing Owner { get; }

    public Component(Thing owner)
    {
        Owner = owner;
    }
}
