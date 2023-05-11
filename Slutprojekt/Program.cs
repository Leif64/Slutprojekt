using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(800, 450, "Slutprojekt");                           // Initierar fönstret med bredden 800 och höjden 450

        List<JumpingPlayer> players = new List<JumpingPlayer>();              // Skapar en lista av Player

        // Lägg till spelare i listan
        players.Add(new JumpingPlayer());

        // Skapa instanser av Collectible och Platform
        Collectible collectible = new Collectible();
        Platform platform = new Platform();

        Raylib.SetTargetFPS(60);                                              // Sätter 60 fps

        while (!Raylib.WindowShouldClose())                                   // Startar en loop som kör spelet tills fönstret stängs
        {
            // Uppdatera alla spelare i listan
            foreach (JumpingPlayer player in players)
            {
                player.Update(collectible, platform);
            }

            collectible.Update();                                              // Uppdaterar samlarobjektet

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            // Rita ut alla spelare i listan
            foreach (JumpingPlayer player in players)
            {
                player.Draw();
            }

            collectible.Draw();                                               // Ritar ut samlarobjektet och plattformen
            platform.Draw();

            Raylib.EndDrawing();                                              // Avslutar utritningen och börjar om loopen

        }

        Raylib.CloseWindow();
    }
}