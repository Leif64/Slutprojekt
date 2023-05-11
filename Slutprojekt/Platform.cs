using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Platform
{
    public float X { get; set; }
    public float Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Color Color { get; set; }

    public Platform()
    {
        X = 0;
        Y = 400;
        Width = 800;
        Height = 50;
        Color = Color.BLACK;
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(new Rectangle(X, Y, Width, Height), Color);
    }
}
