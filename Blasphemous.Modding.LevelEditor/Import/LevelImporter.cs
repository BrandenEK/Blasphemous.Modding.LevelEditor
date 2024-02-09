using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blasphemous.Modding.LevelEditor.Import;

public static class LevelImporter
{
    public static IEnumerable<Thing> Load(string level)
    {
        return LoadInternal(level).Select(x => Thing.Import(x));
    }

    private static IEnumerable<ThingImport> LoadInternal(string level)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "import", "levels", $"{level}.json");

        if (!File.Exists(path))
            return Array.Empty<ThingImport>();

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<ThingImport[]>(json) ?? Array.Empty<ThingImport>();
    }
}
