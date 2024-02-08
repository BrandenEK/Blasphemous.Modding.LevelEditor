using System.Drawing;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor.UI;

public class ScaleablePanel : Panel, IRescaleable
{
    public Point XRange { get; set; } = new Point(0, 100);
    public Point YRange { get; set; } = new Point(0, 100);

    public Point XOffset { get; set; } = new Point(0, 0);
    public Point YOffset { get; set; } = new Point(0, 0);

    public void Rescale(Size total)
    {
        float left = XRange.X / 100f * total.Width;
        float right = XRange.Y / 100f * total.Width;
        float bottom = YRange.X / 100f * total.Height;
        float top = YRange.Y / 100f * total.Height;

        Location = new Point((int)left + XOffset.X, (int)bottom + YOffset.X);
        Size = new Size((int)(right - left) + XOffset.Y - XOffset.X, (int)(top - bottom) + YOffset.Y - YOffset.X);
    }
}
