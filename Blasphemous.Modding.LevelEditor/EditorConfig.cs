
namespace Blasphemous.Modding.LevelEditor;

public class EditorConfig
{
    public WindowState Window { get; set; } = new();

    public class WindowState
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool IsMaximized { get; set; } = true;
    }
}
