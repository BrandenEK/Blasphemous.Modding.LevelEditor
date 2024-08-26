using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Import;
using System;
using System.Collections.Generic;
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

    public WindowInfo CreateInfoWindow() => new(_info_text);

    public WindowGrid CreateGridWindow() => new(_grid_contents, _info_text);

    public WindowTool CreateToolWindow() => new();

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
