using System;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

internal static class Core
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(Editor = new Editor());

        Grid = new(new Panel());
        Info = new(new Label());
    }

    public static Editor Editor { get; private set; }
    public static WindowGrid Grid { get; private set; }
    public static WindowInfo Info { get; private set; }
}