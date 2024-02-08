using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

public class WindowInfo
{
    private readonly Label _infoText;

    public WindowInfo(Label infoText)
    {
        _infoText = infoText;
    }

    //public void OnClickButton()
    //{
    //    Refresh();
    //}

    public void Refresh()
    {
        StringBuilder sb = new();

        Point cursor = Core.Grid.CursorPosition;
        sb.AppendLine($"Cursor: {cursor.X}, {cursor.Y}");

        int objects = Core.Grid.GridObjects.Count();
        sb.AppendLine($"Objects: {objects}");

        string selected = Core.Grid.SelectedObject;
        sb.AppendLine($"Selected: {selected}");

        sb.AppendLine(_message);

        _infoText.Text = sb.ToString();
    }

    private string _message = string.Empty;
    public string Message
    {
        set
        {
            _message = value;
            Refresh();
        }
    }
}
