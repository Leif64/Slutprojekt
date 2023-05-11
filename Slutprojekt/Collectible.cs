using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Collectible
{
    public float X { get; set; }
    public float Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Color Color { get; set; }

    public Collectible()
    {
        X = 700;
        Y = 400;
        Width = 30;
        Height = 30;
        Color = Color.YELLOW;
    }

    public void Update()
    {
        // framtids planer
    }

    public void Draw()
    {
    }
}
