using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Import;
using Blasphemous.Modding.LevelEditor.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

public partial class MainForm : Form
{
    public const int PIXELS_PER_UNIT = 32;

    public const string SCENE = "D04Z01S01";

    public MainForm()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;
    }

    // Windows

    public WindowInfo CreateInfoWindow() => new(info_text);

    public WindowGrid CreateGridWindow() => new(grid_contents, info_text);

    public WindowTool CreateToolWindow() => new();

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
        Logger.Info($"Loading level {SCENE}");
        IEnumerable<Thing> objects = LevelImporter.Load(SCENE);
        Core.Grid.LoadLevel(objects);
    }
}
