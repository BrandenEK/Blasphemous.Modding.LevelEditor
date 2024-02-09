using Blasphemous.Modding.LevelEditor.Components;
using System.Collections.Generic;
using System.Linq;

namespace Blasphemous.Modding.LevelEditor;

public static class Extensions
{
    public static IEnumerable<Thing> SortBackToFront(this IEnumerable<Thing> objects)
    {
        return objects.OrderBy(x => x.Sprite.SortingLayer * 1000000 + x.Sprite.SortingOrder);
    }
}
