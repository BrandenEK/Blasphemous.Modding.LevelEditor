using System.Drawing;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor.UI;

public class BorderedPanel : Panel, IRescaleable
{
    public void Rescale(Size total)
    {
        total = Parent.Size;

        Location = new Point(2, 2);
        Size = new Size(total.Width - 4, total.Height - 4);
    }
}
