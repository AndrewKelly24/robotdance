using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;

    public double x { get; private set; }
    public double y { get; private set; }

    public bool Quit { get; private set; }    

    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }

    public Player(Window gameWindow)
    {
        _PlayerBitmap = new Bitmap("player", "Player.png");
        x = (gameWindow.Width / 2) - _PlayerBitmap.Width / 2;
        y = (gameWindow.Height / 2) - _PlayerBitmap.Height / 2;
        Quit = false;
    }

    public void Draw()
    {
        _PlayerBitmap.Draw(x, y);
    }

    public void HandleInput()
    {
        const int SPEED = 5;

        SplashKit.ProcessEvents();
        if(SplashKit.KeyDown(KeyCode.LeftKey))
        {
            x -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            x += SPEED;
        }
        if(SplashKit.KeyDown(KeyCode.UpKey))
        {
            y -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            y += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.EscapeKey)
        )
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window gameWindow)
    {
        const int GAP = 10;

        if (x < GAP)
        {
            x = GAP;
        }
        if (x + _PlayerBitmap.Width > gameWindow.Width - GAP)
        {
            x = gameWindow.Width - GAP - _PlayerBitmap.Width;
        }
        if (y < GAP)
        {
            y = GAP;
        }
        if (y + _PlayerBitmap.Height > gameWindow.Height - GAP)
        {
            y = gameWindow.Height - GAP - _PlayerBitmap.Height;
        }
    }

}