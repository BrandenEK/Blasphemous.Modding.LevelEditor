using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Framework;
using Blasphemous.Modding.LevelEditor.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

public partial class Editor : Form
{
    public const int PIXELS_PER_UNIT = 32;

    public Editor()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;
    }

    // Windows

    public WindowInfo CreateInfoWindow() => new(info_text);

    public WindowGrid CreateGridWindow() => new(grid_contents);

    public WindowTool CreateToolWindow() => new();

    // Json loading

    private void LoadLevelObjects()
    {
        List<Thing> objects = new();

        foreach (var group in LoadObjects().GroupBy(x => x.sprite.layer).OrderBy(x => x.Key))
        {
            foreach (var obj in group.OrderBy(x => x.sprite.order))
            {
                objects.Add(Thing.Import(obj));
            }
        }

        Core.Grid.GridObjects = objects;
        Core.Grid.CenterGrid();
    }

    private IEnumerable<ThingImport> LoadObjects()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "import", "levels", "D04Z01S01.json");
        Logger.Warning($"Importing level data from {path}");

        if (!File.Exists(path))
            return Array.Empty<ThingImport>();

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<ThingImport[]>(json) ?? Array.Empty<ThingImport>();
    }

    //private Bitmap? LoadImage(string name)
    //{
    //    string path = Path.Combine(Environment.CurrentDirectory, "import", "textures", name + ".png");

    //    if (!File.Exists(path))
    //        return null;

    //    return new Bitmap(path);
    //}

    // Rescaling

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        Logger.Info($"Rescaling editor to {ClientRectangle.Size}");
        RescaleControls(this, ClientRectangle.Size);
    }

    private static void RescaleControls(Control c, Size total)
    {
        if (c is IRescaleable rc)
            rc.Rescale(total);

        foreach (Control o in c.Controls)
            RescaleControls(o, total);
    }

    private void OnClickCenter(object sender, EventArgs e)
    {
        Core.Grid.CenterGrid();
    }

    private void OnClickLoad(object sender, EventArgs e)
    {
        LoadLevelObjects();
    }
}
