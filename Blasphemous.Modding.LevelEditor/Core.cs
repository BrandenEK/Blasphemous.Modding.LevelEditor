using System;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

internal static class Core
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Editor());
    }
}