using Raylib_cs;

class JumpingPlayer : Player
{
    private bool isJumping;                          // Initiera variabeln för att kolla om spelaren hoppar
    private float jumpForce;                         // Initiera hoppkraften på spelaren
    private float gravity;                           // Initiera gravitationskraften som drar spelaren mot marken
    private bool isOnGround;                         // Initiera variabeln som kollar om spelaren är på marken

    public JumpingPlayer()
        : base()
    {
        isJumping = false;
        jumpForce = 10.0f;
        gravity = 0.5f;
        isOnGround = true;
    }

    public override void Update(Collectible collectible, Platform platform)
    {
        base.Update(collectible, platform);

        try
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && isOnGround)
            {
                isJumping = true;
                isOnGround = false;
            }
        }
        catch
        {

        }
   

        if (isJumping)
        {
            Y -= jumpForce;                 // Uppdatera spelarens position genom att minska Y-koordinaten med hoppkraften
            jumpForce -= gravity;           // Minska hoppkraften med gravitationskraften för att indentifiera hoppet

            Rectangle playerRect = new Rectangle((int)X, (int)Y, Width, Height);
            Rectangle platformRect = new Rectangle(platform.X, platform.Y, platform.Width, platform.Height);

            if (Raylib.CheckCollisionRecs(playerRect, platformRect))                    // Kolla kollisionen mellan spelaren och plattformen
            {
                isJumping = false;
                isOnGround = true;
                Y = platform.Y - Height;                                                                          // Återställ hoppet när spelaren nuddar plattformen   
                jumpForce = 10.0f;                                                                                // Återställ hoppkraften när spelaren nuddar plattformen
            }
        }
        else
        {
            Rectangle playerRect = new Rectangle((int)X, (int)Y, Width, Height + 1);                              // Lägger till 1 pixel för att kolla om spelaren står på plattformen
            Rectangle platformRect = new Rectangle(platform.X, platform.Y, platform.Width, platform.Height);

            if (Raylib.CheckCollisionRecs(playerRect, platformRect))                                              // Kolla kollision mellan spelaren och plattformen
            {
                isOnGround = true;
            }
            else
            {
                Y += gravity;                                                                                     // Uppdatera spelarens position genom att öka Y-koordinaten med gravitationskraften

                if (Y + Height > platform.Y)                                                                      // Kolla om spelaren är igenom platformen
                {
                    Y = platform.Y - Height;                                                                      // Återställ spelarens Y-koordinat till att vara precis ovanför plattformen
                }
            }
        }
    }
}

