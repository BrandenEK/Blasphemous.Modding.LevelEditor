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
        _grid = new Panel();
        _grid_contents = new Panel();
        _info = new Panel();
        _info_loadBtn = new Button();
        _info_centerBtn = new Button();
        _info_text = new Label();
        _tool = new Panel();
        _tool_text = new Label();
        _grid.SuspendLayout();
        _info.SuspendLayout();
        _tool.SuspendLayout();
        SuspendLayout();
        // 
        // _grid
        // 
        _grid.BackColor = Color.DarkGray;
        _grid.Controls.Add(_grid_contents);
        _grid.Dock = DockStyle.Fill;
        _grid.Location = new Point(0, 0);
        _grid.Name = "_grid";
        _grid.Size = new Size(964, 481);
        _grid.TabIndex = 0;
        // 
        // _grid_contents
        // 
        _grid_contents.BackColor = Color.SteelBlue;
        _grid_contents.Location = new Point(0, 0);
        _grid_contents.Name = "_grid_contents";
        _grid_contents.Size = new Size(50000, 50000);
        _grid_contents.TabIndex = 1;
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
        // _tool
        // 
        _tool.BackColor = Color.Silver;
        _tool.BorderStyle = BorderStyle.Fixed3D;
        _tool.Controls.Add(_tool_text);
        _tool.Dock = DockStyle.Bottom;
        _tool.Location = new Point(0, 481);
        _tool.Name = "_tool";
        _tool.Size = new Size(964, 200);
        _tool.TabIndex = 0;
        // 
        // _tool_text
        // 
        _tool_text.Dock = DockStyle.Fill;
        _tool_text.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        _tool_text.ForeColor = Color.DimGray;
        _tool_text.Location = new Point(0, 0);
        _tool_text.Name = "_tool_text";
        _tool_text.Size = new Size(960, 196);
        _tool_text.TabIndex = 0;
        _tool_text.Text = "Toolbox...";
        _tool_text.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1264, 681);
        Controls.Add(_grid);
        Controls.Add(_tool);
        Controls.Add(_info);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(1280, 720);
        Name = "MainForm";
        Text = "Blasphemous Level Editor";
        _grid.ResumeLayout(false);
        _info.ResumeLayout(false);
        _tool.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel grid_border;
    private Panel _grid;
    private Panel _info;
    private Panel _tool;
    private Panel _grid_contents;
    private Label _info_text;
    private Label _tool_text;
    private Button _info_centerBtn;
    private Button _info_loadBtn;
}
