using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor.UI;

public class GridImage : Panel
{
    private readonly Action<Graphics> _draw;

    public GridImage(Action<Graphics> draw, Size size)
    {
        _draw = draw;
        Size = size;
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

            return cp;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Set the best settings possible (quality-wise)
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        _draw(e.Graphics);
    }

    protected override void OnPaintBackground(PaintEventArgs e) { }
}
