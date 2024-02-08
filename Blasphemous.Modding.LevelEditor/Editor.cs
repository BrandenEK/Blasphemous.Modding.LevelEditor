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
        OnResize(new EventArgs());

        //GridHandler = new(grid_contents);
        //InfoHandler = new(info_text);

        foreach (var group in LoadObjects().GroupBy(x => x.sprite.layer).OrderBy(x => x.Key))
        {
            foreach (var obj in group.OrderBy(x => x.sprite.order))
            {
                AddSpriteToGrid(obj);
            }
        }

        // Aren't set before this contructor
        //Core.Grid.GridObjects = _objectsInLevel;
        //Core.Info.Refresh();
    }

    // Grid management

    // List of all objects in the level, each one has different components and each component probably has a drawing in the grid
    private readonly List<Thing> _objectsInLevel = new();

    private void AddSpriteToGrid(ThingImport info)
    {
        Thing obj = new();
        obj.Name = info.name;

        obj.Transform.Position = info.transform.position;
        obj.Transform.Rotation = info.transform.rotation;
        obj.Transform.Scale = info.transform.scale;

        obj.Sprite.Image = LoadImage(info.sprite.image);
        obj.Sprite.SortingLayer = info.sprite.layer;
        obj.Sprite.SortingOrder = info.sprite.order;
        obj.Sprite.HorizontalFlip = info.sprite.flip;
        obj.Sprite.Pivot = info.sprite.pivot;

        // Collider

        obj.Transform.Refresh();
        _objectsInLevel.Add(obj);
    }

    // Json loading

    private IEnumerable<ThingImport> LoadObjects()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "import", "levels", "D04Z01S01.json");

        if (!File.Exists(path))
            return Array.Empty<ThingImport>();

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<ThingImport[]>(json) ?? Array.Empty<ThingImport>();
    }

    private Bitmap? LoadImage(string name)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "import", "textures", name + ".png");

        if (!File.Exists(path))
            return null;

        return new Bitmap(path);
    }

    // Rescaling

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        RescaleControls(this, ClientRectangle.Size);
    }

    private void RescaleControls(Control c, Size total)
    {
        if (c is IRescaleable rc)
            rc.Rescale(total);

        foreach (Control o in c.Controls)
            RescaleControls(o, total);
    }

    private void OnClickInfo(object sender, EventArgs e)
    {
        Core.Info.OnClickButton();
        Core.Grid.CenterGrid();
    }
}
