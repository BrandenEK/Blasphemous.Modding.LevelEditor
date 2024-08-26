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
        _info = new Panel();
        _info_loadBtn = new Button();
        _info_centerBtn = new Button();
        _info_text = new Label();
        tool_border = new ScaleablePanel();
        tool_section = new BorderedPanel();
        tool_text = new Label();
        grid_border.SuspendLayout();
        grid_section.SuspendLayout();
        _info.SuspendLayout();
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
        // _info
        // 
        _info.BackColor = Color.LightGray;
        _info.BorderStyle = BorderStyle.Fixed3D;
        _info.Controls.Add(_info_loadBtn);
        _info.Controls.Add(_info_centerBtn);
        _info.Controls.Add(_info_text);
        _info.Dock = DockStyle.Right;
        _info.Location = new Point(964, 0);
        _info.Name = "_info";
        _info.Size = new Size(300, 681);
        _info.TabIndex = 0;
        // 
        // _info_loadBtn
        // 
        _info_loadBtn.Anchor = AnchorStyles.Bottom;
        _info_loadBtn.Location = new Point(68, 508);
        _info_loadBtn.Name = "_info_loadBtn";
        _info_loadBtn.Size = new Size(75, 23);
        _info_loadBtn.TabIndex = 2;
        _info_loadBtn.Text = "Load";
        _info_loadBtn.UseVisualStyleBackColor = true;
        _info_loadBtn.Click += OnClickLoad;
        // 
        // _info_centerBtn
        // 
        _info_centerBtn.Anchor = AnchorStyles.Bottom;
        _info_centerBtn.Location = new Point(150, 508);
        _info_centerBtn.Name = "_info_centerBtn";
        _info_centerBtn.Size = new Size(75, 23);
        _info_centerBtn.TabIndex = 1;
        _info_centerBtn.Text = "Center";
        _info_centerBtn.UseVisualStyleBackColor = true;
        _info_centerBtn.Click += OnClickCenter;
        // 
        // _info_text
        // 
        _info_text.Dock = DockStyle.Bottom;
        _info_text.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        _info_text.ForeColor = Color.DimGray;
        _info_text.Location = new Point(0, 557);
        _info_text.Name = "_info_text";
        _info_text.Size = new Size(296, 120);
        _info_text.TabIndex = 0;
        _info_text.Text = "Info...";
        _info_text.TextAlign = ContentAlignment.MiddleCenter;
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
        Controls.Add(_info);
        Controls.Add(tool_border);
        Controls.Add(grid_border);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(1280, 720);
        Name = "MainForm";
        Text = "Blasphemous Level Editor";
        grid_border.ResumeLayout(false);
        grid_section.ResumeLayout(false);
        _info.ResumeLayout(false);
        tool_border.ResumeLayout(false);
        tool_section.ResumeLayout(false);
        ResumeLayout(false);
    }

    private ScaleablePanel grid_border;
    private BorderedPanel grid_section;
    private Panel _info;
    private ScaleablePanel tool_border;
    private BorderedPanel tool_section;
    private Panel grid_contents;
    private Label _info_text;
    private Label tool_text;
    private Button _info_centerBtn;
    private Button _info_loadBtn;
}
