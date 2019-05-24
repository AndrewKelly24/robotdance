using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;
    private Bitmap _HeartBitmap;

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

    public int health;
    public Player(Window gameWindow)
    {
        _PlayerBitmap = new Bitmap("player", "Player.png");
        _HeartBitmap = new Bitmap("heart", "heart.png");
        x = (gameWindow.Width / 2) - _PlayerBitmap.Width / 2;
        y = (gameWindow.Height / 2) - _PlayerBitmap.Height / 2;
        Quit = false;
        health = 5;
    }

    public void Draw()
    {
        _PlayerBitmap.Draw(x, y);        
    }

    public void HandleInput()
    {
        const int SPEED = 5;

        
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            x -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            x += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.UpKey))
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

    public bool CollidedWith(Robot robot)
    {
        bool collide = _PlayerBitmap.CircleCollision(x, y, robot.CollisionCircle);    

        if (collide)
        {
            health--;
        }
        return collide;    
    }


    public void DrawHealth(Window gameWindow)
    {
        int heart_y = 20;
        int x_offset = 20;
        for (int i = 1; i <= health; i++)
        {
            _HeartBitmap.Draw(gameWindow.Width - (_HeartBitmap.Width * i + x_offset * i), heart_y);
        }
    }
    public void UpdateHealth()
    {
        if (health == 0) 
            Quit = true;
    }
}