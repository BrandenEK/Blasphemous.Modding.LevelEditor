using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Blasphemous.Modding.LevelEditor.Import;

public static class TextureImporter
{
    public static Bitmap? Load(string name)
    {
        if (_cache.ContainsKey(name))
            return _cache[name];

        string path = Path.Combine(Environment.CurrentDirectory, "import", "textures", name + ".png");

        Bitmap? image = File.Exists(path) ? new Bitmap(path) : null;
        _cache.Add(name, image);
        return image;
    }

    private static readonly Dictionary<string, Bitmap?> _cache = new();
}
