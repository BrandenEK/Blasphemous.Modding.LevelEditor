using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Import;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Blasphemous.Modding.LevelEditor;

public partial class MainForm : BasaltForm
{
    public const int PIXELS_PER_UNIT = 32;
    public const string SCENE = "D04Z01S01";

    protected override void OnFormOpenPre()
    {
        EditorConfig cfg = LoadSettings();
        WindowState = cfg.Window.IsMaximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Location = cfg.Window.Location;
        Size = cfg.Window.Size;
    }

    protected override void OnFormClose(FormClosingEventArgs e)
    {
        EditorConfig cfg = new()
        {
            Window = new EditorConfig.WindowState()
            {
                Location = WindowState == FormWindowState.Normal ? Location : RestoreBounds.Location,
                Size = WindowState == FormWindowState.Normal ? Size : RestoreBounds.Size,
                IsMaximized = WindowState == FormWindowState.Maximized
            }
        };
        SaveSettings(cfg);
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

    // Config

    private static void SaveSettings(EditorConfig cfg)
    {
        JsonSerializerSettings settings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        string json = JsonConvert.SerializeObject(cfg, settings);
        File.WriteAllText(Path.Combine(Core.EditorFolder, "Settings.cfg"), json);
    }

    private static EditorConfig LoadSettings()
    {
        string path = Path.Combine(Core.EditorFolder, "Settings.cfg");

        var cfg = new EditorConfig();
        try
        {
            cfg = JsonConvert.DeserializeObject<EditorConfig>(File.ReadAllText(path))!;
        }
        catch
        {
            Logger.Error($"Failed to read config from {path}");
        }

        SaveSettings(cfg);
        return cfg;
    }
}
