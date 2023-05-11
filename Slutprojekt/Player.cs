using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Player
{
    public float X { get; set; }
    public float Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Color Color { get; set; }

    public Player()
    {
        X = 50;
        Y = 350;
        Width = 50;
        Height = 50;
        Color = Color.RED;
    }

    public virtual void Update(Collectible collectible, Platform platform)
    {

        float playerSpeed = 5.0f;                                             // Definierar spelarens hastighet.


        Vector2 playerPosition = new Vector2(X, Y);                           // Definierar och initierar spelarens position med nuvarande X- och Y-koordinater.


        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            playerPosition += new Vector2(playerSpeed, 0);                    // Flyttar spelaren åt höger eller vänster beroende på vilken tangent som trycks ner.
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            playerPosition += new Vector2(-playerSpeed, 0);
        }


        Rectangle playerRect = new Rectangle(playerPosition.X, playerPosition.Y, Width, Height);          // Kontrollerar kollision med plattformen genom att skapa två rektanglar.
                                                                                                          // en för spelaren och en för plattformen, och sedan kontrollera om de överlappar.
        Rectangle platformRect = new Rectangle(platform.X, platform.Y, platform.Width, platform.Height);

        if (Raylib.CheckCollisionRecs(playerRect, platformRect))
        {

            playerPosition.Y = platform.Y - Height;                           // Om kollision sker sätts spelarens Y-koordinat till samma som toppkanten på plattformen.
        }


        X = playerPosition.X;                                                 // Uppdaterar spelarens position.
        Y = playerPosition.Y;


        CheckCollision(collectible);                                          // Kontrollerar kollision med samlarobjektet genom att kalla på metoden CheckCollision().
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)X, (int)Y, Width, Height, Color);           // Ritar ut en rektangel som representerar spelaren.
    }

    private void CheckCollision(Collectible collectible)
    {

        Rectangle playerRect = new Rectangle((int)X, (int)Y, Width, Height);
        Rectangle collectibleRect = new Rectangle((int)collectible.X, (int)collectible.Y, collectible.Width, collectible.Height);

        if (Raylib.CheckCollisionRecs(playerRect, collectibleRect))
        {
            // framtids planer
        }
    }
}