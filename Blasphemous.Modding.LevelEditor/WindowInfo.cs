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
}
