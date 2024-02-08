using Blasphemous.Modding.LevelEditor.Components;
using Blasphemous.Modding.LevelEditor.Framework;
using Blasphemous.Modding.LevelEditor.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blasphemous.Modding.LevelEditor;

public class WindowGrid
{
    private bool _clicked;
    private Point _lastPosition;
    private Point _gridCenter;

    private Thing? _selectedObject;

    private readonly List<Thing> _gridObjects;
    private readonly Panel _gridContents;
    private readonly GridImage _image;

    public Point CursorPosition => _lastPosition;
    public string SelectedObject => _selectedObject?.Name ?? "None";

    public WindowGrid(Panel gridContents)
    {
        _gridObjects = new List<Thing>();
        _gridContents = gridContents;
        _image = new GridImage(DrawGrid, _gridContents.Size);
        AddImageToGrid(_image);
        CenterGrid();
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
        _gridObjects.AddRange(objects);

        CenterGrid();
    }

    // Mouse clicking and scrolling

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

        Core.Info.Refresh();
    }

    private Point ScrollGrid(Point cursor)
    {
        Point diff = new Point(cursor.X - _lastPosition.X, cursor.Y - _lastPosition.Y);
        SetGridPosition(new Point(_gridContents.Location.X + diff.X, _gridContents.Location.Y + diff.Y));

        return new Point(cursor.X - diff.X, cursor.Y - diff.Y);
    }

    public void CenterGrid()
    {
        Logger.Info("Centering grid");
        SetGridPosition(_gridCenter);
    }

    private void SetGridPosition(Point position)
    {
        int xmax = _gridContents.Width - _gridContents.Parent.Width;
        int ymax = _gridContents.Height - _gridContents.Parent.Height;

        int x = Math.Min(0, Math.Max(-xmax, position.X));
        int y = Math.Min(0, Math.Max(-ymax, position.Y));

        _gridContents.Location = new Point(x, y);
    }

    public void RefreshGrid()
    {
        _image.Invalidate();
    }

    private void DrawGrid(Graphics g)
    {
        DateTime startTime = DateTime.Now;

        float top = int.MaxValue, left = int.MaxValue;
        float right = int.MinValue, bottom = int.MinValue;

        Vector origin = new(_gridContents.Width / 2, _gridContents.Height / 2, 0);

        foreach (var obj in _gridObjects)
        {
            if (!obj.Sprite.DrawImage(g, origin, out Vector tl, out Vector br))
                continue;

            if (tl.Y < top)
                top = tl.Y;
            if (tl.X < left)
                left = tl.X;
            if (br.X > right)
                right = br.X;
            if (br.Y > bottom)
                bottom = br.Y;
        }

        _selectedObject?.Sprite.DrawOutline(g, origin);

        float x = left + (right - left) / 2f - _gridContents.Parent.Width / 2f;
        float y = top + (bottom - top) / 2f - _gridContents.Parent.Height / 2f;
        _gridCenter = new Point((int)-x, (int)-y);

        DateTime endTime = DateTime.Now;

        Logger.Warning($"Redrawing grid in {(endTime - startTime).TotalMilliseconds} ms");
        Core.Info.Message = $"Draw count: {++drawCount}";
    }

    private static int drawCount = 0;

    private void ClickOnGrid(Vector mouse)
    {
        Vector origin = new(_gridContents.Width / 2, _gridContents.Height / 2, 0);

        //if (_selectedObject != null)
        //{
        //    FourPoint fp = _selectedObject.Sprite.GetImageRect(origin);
        //    _image.Invalidate(new Rectangle(fp.TopLeft, fp.Size + Vector.One));
        //}    

        _selectedObject = SortObjectsByRenderOrder().FirstOrDefault(x => x.Sprite.Image != null && x.Sprite.GetImageRect(origin).IsPointInside(mouse));
        Logger.Info($"Selecting new object: {_selectedObject?.Name ?? "None"}");
        //if (_selectedObject != null)
        //{
        //    FourPoint fp = _selectedObject.Sprite.GetImageRect(origin);
        //    _image.Invalidate(new Rectangle(fp.TopLeft, fp.Size + Vector.One));
        //}

        RefreshGrid();
        Core.Info.Refresh();
    }

    private IEnumerable<Thing> SortObjectsByRenderOrder() =>
        _gridObjects.OrderByDescending(x => x.Sprite.SortingLayer * 1000000 + x.Sprite.SortingOrder);
}
