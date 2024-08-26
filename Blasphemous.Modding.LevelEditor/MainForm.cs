using Basalt.BetterForms;
using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Import;

namespace Blasphemous.Modding.LevelEditor;

public partial class MainForm : BasaltForm
{
    public const int PIXELS_PER_UNIT = 32;
    public const string SCENE = "D04Z01S01";

    protected override void OnFormOpenPre()
    {
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
