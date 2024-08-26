using Basalt.BetterForms;

namespace Blasphemous.Modding.LevelEditor;

internal static class Core
{
    [STAThread]
    static void Main()
    {
        BasaltApplication.Run<MainForm, EditorCommand>(InitializeWindows, "Blasphemous Level Editor", new string[]
        {
            EditorFolder
        });
    }

    static void InitializeWindows(MainForm form, EditorCommand cmd)
    {
        Editor = form;
        Grid = Editor.CreateGridWindow();
        Info = Editor.CreateInfoWindow();
        Tool = Editor.CreateToolWindow();
    }

    public static MainForm Editor { get; private set; }
    public static WindowGrid Grid { get; private set; }
    public static WindowInfo Info { get; private set; }
    public static WindowTool Tool { get; private set; }

    public static string EditorFolder { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlasLevelEditor");
}