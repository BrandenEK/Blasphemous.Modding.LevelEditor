using System;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

internal static class Core
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Editor = new Editor();
        Grid = Editor.CreateGridWindow();
        Info = Editor.CreateInfoWindow();
        Tool = Editor.CreateToolWindow();

        Application.Run(Editor);
    }

    public static Editor Editor { get; private set; }
    public static WindowGrid Grid { get; private set; }
    public static WindowInfo Info { get; private set; }
    public static WindowTool Tool { get; private set; }
}