﻿using Basalt.Framework.Logging;
using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Framework;
using Blasphemous.Modding.LevelEditor.UI;
using System.Text;

namespace Blasphemous.Modding.LevelEditor;

public class WindowGrid
{
    private bool _clicked;
    private Point _lastPosition;

    private Thing? _selectedObject;

    private readonly List<Thing> _gridObjects;
    private readonly Panel _gridContents;
    private readonly GridImage _image;
    //private readonly GridImage _text;
    private readonly Label _info;

    public Point CursorPosition => _lastPosition;
    public string SelectedObject => _selectedObject?.Name ?? "None";

    public WindowGrid(Panel gridContents, Label info)
    {
        _gridObjects = new List<Thing>();
        _gridContents = gridContents;
        _image = new GridImage(DrawGrid, _gridContents.Size);
        AddImageToGrid(_image);
        _info = info;
        //_text = new GridImage(DrawText, new Size(400, 150));
        //Core.Editor.Controls.Add(_text);
        //Core.Editor.Controls.SetChildIndex(_text, 0);
        CenterGrid();
        RefreshText();
    }

    private void AddImageToGrid(GridImage image)
    {
        _gridContents.Controls.Add(image);
        image.MouseDown += OnMouseDown;
        image.MouseUp += OnMouseUp;
        image.MouseMove += OnMouseMove;
    }

    public void LoadLevel(IEnumerable<Thing> objects)
    {
        _gridObjects.Clear();
        _gridObjects.AddRange(objects.SortBackToFront()); // Also need to sort when adding objects

        CenterGrid();
    }

    // Text drawing

    private void DrawText(Graphics g)
    {
        Font font = new Font(FontFamily.GenericSerif, 16);
        Brush brush = new SolidBrush(Color.White);

        //TextRenderer.DrawText(g, sb.ToString(), font, new Point(5, 5), Color.White);
        //var size = g.MeasureString(sb.ToString(), font);
        //_text.Size = new Size((int)size.Width, (int)size.Height);
        //g.Clear(Color.Transparent);
        //g.DrawString(sb.ToString(), font, Brushes.White, new PointF(5, 5));// new PointF(-_gridContents.Location.X, -_gridContents.Location.Y));
    }

    private void RefreshText()
    {
        //_text.Invalidate();
        _info.Text = BuildInfoText();
    }

    private string BuildInfoText()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Scene: {MainForm.SCENE}");
        sb.AppendLine($"Objects: {_gridObjects.Count}");
        sb.AppendLine($"Selected: {_selectedObject?.Name ?? "None"}");

        Vector cursor = new Vector(_lastPosition.X, _lastPosition.Y, 0);
        cursor = ConvertToWorldSpace(cursor) / MainForm.PIXELS_PER_UNIT;

        sb.AppendLine($"Cursor: ({MathF.Round(cursor.X, 2)}, {MathF.Round(cursor.Y, 2)})");

        return sb.ToString();
    }

    // Mouse events

    private void OnMouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            ClickOnGrid(new Vector(e.X, e.Y, 0));

        if (e.Button == MouseButtons.Right)
            _clicked = true;
    }

    private void OnMouseUp(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
            _clicked = false;
    }

    private void OnMouseMove(object? sender, MouseEventArgs e)
    {
        if (_clicked)
        {
            _lastPosition = ScrollGrid(new Point(e.X, e.Y));
        }
        else
        {
            _lastPosition = new Point(e.X, e.Y);
        }

        RefreshText();
    }

    // Grid movement

    private Point ScrollGrid(Point cursor)
    {
        Point diff = new Point(cursor.X - _lastPosition.X, cursor.Y - _lastPosition.Y);
        SetGridPosition(new Point(_gridContents.Location.X + diff.X, _gridContents.Location.Y + diff.Y));

        return new Point(cursor.X - diff.X, cursor.Y - diff.Y);
    }

    public void CenterGrid()
    {
        Logger.Info("Centering grid");
        SetGridPosition(CenterPoint);
    }

    private void SetGridPosition(Point position)
    {
        int xmax = _gridContents.Width - _gridContents.Parent.Width;
        int ymax = _gridContents.Height - _gridContents.Parent.Height;

        int x = Math.Min(0, Math.Max(-xmax, position.X));
        int y = Math.Min(0, Math.Max(-ymax, position.Y));

        _gridContents.Location = new Point(x, y);
    }

    // Grid drawing

    public void RefreshGrid()
    {
        _image.Invalidate();
    }

    private void DrawGrid(Graphics g)
    {
        DateTime startTime = DateTime.Now;

        // Draw all sprites
        foreach (var obj in _gridObjects)
        {
            if (obj.Sprite.Image == null)
                continue;

            g.DrawImage(obj.Sprite.Image, ConvertToGridSpace(obj.Sprite.Points).AsArray());
        }

        // Draw all colliders

        // Draw outline on selected object
        if (_selectedObject != null)
        {
            Pen p = new(Color.Cyan, 1f);
            g.DrawRectangle(p, ConvertToGridSpace(_selectedObject.Sprite.Points).AsRectangle());
        }

        DateTime endTime = DateTime.Now;

        Logger.Warn($"Redrawing grid in {(endTime - startTime).TotalMilliseconds} ms");
    }

    private Vector CenterPoint
    {
        get
        {
            float top = int.MaxValue, left = int.MaxValue;
            float right = int.MinValue, bottom = int.MinValue;

            foreach (var obj in _gridObjects)
            {
                FourPoint points = ConvertToGridSpace(obj.Sprite.Points);

                if (points.TopLeft.Y < top)
                    top = points.TopLeft.Y;
                if (points.TopLeft.X < left)
                    left = points.TopLeft.X;
                if (points.BottomRight.X > right)
                    right = points.BottomRight.X;
                if (points.BottomRight.Y > bottom)
                    bottom = points.BottomRight.Y;
            }

            float x = left + (right - left) / 2f - _gridContents.Parent.Width / 2f;
            float y = top + (bottom - top) / 2f - _gridContents.Parent.Height / 2f;
            return new Vector(-x, -y, 0);
        }
    }

    private static int drawCount = 0;

    private void ClickOnGrid(Vector mouse)
    {
        _selectedObject = _gridObjects.LastOrDefault(x =>
            x.Sprite.Image != null && ConvertToGridSpace(x.Sprite.Points).IsPointInside(mouse));

        Logger.Info($"Selecting new object: {_selectedObject?.Name ?? "None"}");

        RefreshGrid();
        RefreshText();
    }

    private FourPoint ConvertToGridSpace(FourPoint points)
    {
        Vector pixelMirror = new(1, -1, 1);
        Vector origin = new(_gridContents.Width / 2, _gridContents.Height / 2, 0);

        return points.Apply(v => v * pixelMirror + origin);
    }

    private Vector ConvertToWorldSpace(Vector vector)
    {
        Vector pixelMirror = new(1, -1, 1);
        Vector origin = new(_gridContents.Width / 2, _gridContents.Height / 2, 0);

        return vector * pixelMirror - origin;
    }
}
