using Blasphemous.Modding.LevelEditor.UI;
using System.Drawing;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        grid_border = new ScaleablePanel();
        grid_section = new BorderedPanel();
        grid_contents = new Panel();
        info_border = new ScaleablePanel();
        info_section = new BorderedPanel();
        info_load_btn = new Button();
        info_center_btn = new Button();
        info_text = new Label();
        tool_border = new ScaleablePanel();
        tool_section = new BorderedPanel();
        tool_text = new Label();
        grid_border.SuspendLayout();
        grid_section.SuspendLayout();
        info_border.SuspendLayout();
        info_section.SuspendLayout();
        tool_border.SuspendLayout();
        tool_section.SuspendLayout();
        SuspendLayout();
        // 
        // grid_border
        // 
        grid_border.BackColor = Color.Black;
        grid_border.Controls.Add(grid_section);
        grid_border.Location = new Point(0, 0);
        grid_border.Name = "grid_border";
        grid_border.Size = new Size(640, 360);
        grid_border.TabIndex = 3;
        grid_border.XOffset = new Point(-3, 0);
        grid_border.XRange = new Point(0, 80);
        grid_border.YOffset = new Point(0, 0);
        grid_border.YRange = new Point(0, 70);
        // 
        // grid_section
        // 
        grid_section.BackColor = Color.DarkGray;
        grid_section.Controls.Add(grid_contents);
        grid_section.Location = new Point(0, 0);
        grid_section.Name = "grid_section";
        grid_section.Size = new Size(640, 360);
        grid_section.TabIndex = 0;
        // 
        // grid_contents
        // 
        grid_contents.BackColor = Color.SteelBlue;
        grid_contents.Location = new Point(0, 0);
        grid_contents.Name = "grid_contents";
        grid_contents.Size = new Size(50000, 50000);
        grid_contents.TabIndex = 1;
        // 
        // info_border
        // 
        info_border.BackColor = Color.Black;
        info_border.Controls.Add(info_section);
        info_border.Location = new Point(640, 0);
        info_border.Name = "info_border";
        info_border.Size = new Size(160, 500);
        info_border.TabIndex = 4;
        info_border.XOffset = new Point(-2, 3);
        info_border.XRange = new Point(80, 100);
        info_border.YOffset = new Point(0, 3);
        info_border.YRange = new Point(0, 100);
        // 
        // info_section
        // 
        info_section.BackColor = Color.LightGray;
        info_section.Controls.Add(info_load_btn);
        info_section.Controls.Add(info_center_btn);
        info_section.Controls.Add(info_text);
        info_section.Location = new Point(0, 0);
        info_section.Name = "info_section";
        info_section.Size = new Size(160, 500);
        info_section.TabIndex = 0;
        // 
        // info_load_btn
        // 
        info_load_btn.Anchor = AnchorStyles.Bottom;
        info_load_btn.Location = new Point(0, 331);
        info_load_btn.Name = "info_load_btn";
        info_load_btn.Size = new Size(75, 23);
        info_load_btn.TabIndex = 2;
        info_load_btn.Text = "Load";
        info_load_btn.UseVisualStyleBackColor = true;
        info_load_btn.Click += OnClickLoad;
        // 
        // info_center_btn
        // 
        info_center_btn.Anchor = AnchorStyles.Bottom;
        info_center_btn.Location = new Point(82, 331);
        info_center_btn.Name = "info_center_btn";
        info_center_btn.Size = new Size(75, 23);
        info_center_btn.TabIndex = 1;
        info_center_btn.Text = "Center";
        info_center_btn.UseVisualStyleBackColor = true;
        info_center_btn.Click += OnClickCenter;
        // 
        // info_text
        // 
        info_text.Anchor = AnchorStyles.Bottom;
        info_text.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        info_text.ForeColor = Color.DimGray;
        info_text.Location = new Point(-75, 380);
        info_text.Name = "info_text";
        info_text.Size = new Size(300, 120);
        info_text.TabIndex = 0;
        info_text.Text = "Info...";
        info_text.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tool_border
        // 
        tool_border.BackColor = Color.Black;
        tool_border.Controls.Add(tool_section);
        tool_border.Location = new Point(0, 360);
        tool_border.Name = "tool_border";
        tool_border.Size = new Size(640, 140);
        tool_border.TabIndex = 5;
        tool_border.XOffset = new Point(-3, 0);
        tool_border.XRange = new Point(0, 80);
        tool_border.YOffset = new Point(-2, 3);
        tool_border.YRange = new Point(70, 100);
        // 
        // tool_section
        // 
        tool_section.BackColor = Color.Gainsboro;
        tool_section.Controls.Add(tool_text);
        tool_section.Location = new Point(0, 0);
        tool_section.Name = "tool_section";
        tool_section.Size = new Size(640, 101);
        tool_section.TabIndex = 0;
        // 
        // tool_text
        // 
        tool_text.Dock = DockStyle.Fill;
        tool_text.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        tool_text.ForeColor = Color.DimGray;
        tool_text.Location = new Point(0, 0);
        tool_text.Name = "tool_text";
        tool_text.Size = new Size(640, 101);
        tool_text.TabIndex = 0;
        tool_text.Text = "Toolbox...";
        tool_text.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1264, 681);
        Controls.Add(tool_border);
        Controls.Add(info_border);
        Controls.Add(grid_border);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(1280, 720);
        Name = "MainForm";
        Text = "Blasphemous Level Editor";
        grid_border.ResumeLayout(false);
        grid_section.ResumeLayout(false);
        info_border.ResumeLayout(false);
        info_section.ResumeLayout(false);
        tool_border.ResumeLayout(false);
        tool_section.ResumeLayout(false);
        ResumeLayout(false);
    }

    private ScaleablePanel grid_border;
    private BorderedPanel grid_section;
    private ScaleablePanel info_border;
    private BorderedPanel info_section;
    private ScaleablePanel tool_border;
    private BorderedPanel tool_section;
    private Panel grid_contents;
    private Label info_text;
    private Label tool_text;
    private Button info_center_btn;
    private Button info_load_btn;
}
