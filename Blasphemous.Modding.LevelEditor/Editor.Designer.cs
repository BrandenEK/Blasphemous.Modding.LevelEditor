using Blasphemous.Modding.LevelEditor.UI;
using System.Drawing;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

partial class Editor
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
        grid_border = new ScaleablePanel();
        grid_section = new BorderedPanel();
        grid_contents = new Panel();
        info_border = new ScaleablePanel();
        info_section = new BorderedPanel();
        info_button = new Button();
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
        grid_border.BackColor = System.Drawing.Color.Black;
        grid_border.Controls.Add(grid_section);
        grid_border.Location = new System.Drawing.Point(0, 0);
        grid_border.Name = "grid_border";
        grid_border.Size = new System.Drawing.Size(640, 360);
        grid_border.TabIndex = 3;
        grid_border.XOffset = new System.Drawing.Point(-3, 0);
        grid_border.XRange = new System.Drawing.Point(0, 80);
        grid_border.YOffset = new System.Drawing.Point(0, 0);
        grid_border.YRange = new System.Drawing.Point(0, 70);
        // 
        // grid_section
        // 
        grid_section.BackColor = System.Drawing.Color.DarkGray;
        grid_section.Controls.Add(grid_contents);
        grid_section.Location = new System.Drawing.Point(0, 0);
        grid_section.Name = "grid_section";
        grid_section.Size = new System.Drawing.Size(640, 360);
        grid_section.TabIndex = 0;
        // 
        // grid_contents
        // 
        grid_contents.BackColor = System.Drawing.Color.Magenta;
        grid_contents.Location = new System.Drawing.Point(0, 0);
        grid_contents.Name = "grid_contents";
        grid_contents.Size = new System.Drawing.Size(50000, 50000);
        grid_contents.TabIndex = 1;
        // 
        // info_border
        // 
        info_border.BackColor = System.Drawing.Color.Black;
        info_border.Controls.Add(info_section);
        info_border.Location = new System.Drawing.Point(640, 0);
        info_border.Name = "info_border";
        info_border.Size = new System.Drawing.Size(160, 500);
        info_border.TabIndex = 4;
        info_border.XOffset = new System.Drawing.Point(-2, 3);
        info_border.XRange = new System.Drawing.Point(80, 100);
        info_border.YOffset = new System.Drawing.Point(0, 3);
        info_border.YRange = new System.Drawing.Point(0, 100);
        // 
        // info_section
        // 
        info_section.BackColor = System.Drawing.Color.LightGray;
        info_section.Controls.Add(info_button);
        info_section.Controls.Add(info_text);
        info_section.Location = new System.Drawing.Point(0, 0);
        info_section.Name = "info_section";
        info_section.Size = new System.Drawing.Size(160, 500);
        info_section.TabIndex = 0;
        // 
        // info_button
        // 
        info_button.Location = new System.Drawing.Point(39, 385);
        info_button.Name = "info_button";
        info_button.Size = new System.Drawing.Size(75, 23);
        info_button.TabIndex = 1;
        info_button.Text = "Test";
        info_button.UseVisualStyleBackColor = true;
        info_button.Click += OnClickInfo;
        // 
        // info_text
        // 
        info_text.Dock = System.Windows.Forms.DockStyle.Fill;
        info_text.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        info_text.ForeColor = System.Drawing.Color.DimGray;
        info_text.Location = new System.Drawing.Point(0, 0);
        info_text.Name = "info_text";
        info_text.Size = new System.Drawing.Size(160, 500);
        info_text.TabIndex = 0;
        info_text.Text = "Info...";
        info_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tool_border
        // 
        tool_border.BackColor = System.Drawing.Color.Black;
        tool_border.Controls.Add(tool_section);
        tool_border.Location = new System.Drawing.Point(0, 360);
        tool_border.Name = "tool_border";
        tool_border.Size = new System.Drawing.Size(640, 140);
        tool_border.TabIndex = 5;
        tool_border.XOffset = new System.Drawing.Point(-3, 0);
        tool_border.XRange = new System.Drawing.Point(0, 80);
        tool_border.YOffset = new System.Drawing.Point(-2, 3);
        tool_border.YRange = new System.Drawing.Point(70, 100);
        // 
        // tool_section
        // 
        tool_section.BackColor = System.Drawing.Color.Gainsboro;
        tool_section.Controls.Add(tool_text);
        tool_section.Location = new System.Drawing.Point(0, 0);
        tool_section.Name = "tool_section";
        tool_section.Size = new System.Drawing.Size(640, 101);
        tool_section.TabIndex = 0;
        // 
        // tool_text
        // 
        tool_text.Dock = System.Windows.Forms.DockStyle.Fill;
        tool_text.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        tool_text.ForeColor = System.Drawing.Color.DimGray;
        tool_text.Location = new System.Drawing.Point(0, 0);
        tool_text.Name = "tool_text";
        tool_text.Size = new System.Drawing.Size(640, 101);
        tool_text.TabIndex = 0;
        tool_text.Text = "Toolbox...";
        tool_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Editor
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 461);
        Controls.Add(tool_border);
        Controls.Add(info_border);
        Controls.Add(grid_border);
        MinimumSize = new System.Drawing.Size(800, 500);
        Name = "Editor";
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
    private Button info_button;
}
