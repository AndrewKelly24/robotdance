using System;
using SplashKitSDK;

public abstract class Robot
{
    public double X { get; private set; }
    public double Y { get; private set; }

    private Vector2D Velocity { get; set; }
    public Color MainColor { get; set; }

    public int Width
    {
        get { return 50; }
    }

    public int Height
    {
        get { return 50; }
    }

    public Circle CollisionCircle
    {
        get { return SplashKit.CircleAt(X, Y, 20); }
    }

    public Robot(Window gameWindow, Player player)
    {

        if (SplashKit.Rnd() < 0.5)
        {

            X = SplashKit.Rnd(gameWindow.Width);

            if (SplashKit.Rnd() < 0.5)
                Y = -Height;
            else
                Y = gameWindow.Height;
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);

            if (SplashKit.Rnd() < 0.5)
                X = -Width;
            else
                X = gameWindow.Width;
        }

        MainColor = Color.RandomRGB(200);

        const int SPEED = 4;

        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        Point2D toPt = new Point2D()
        {
            X = player.x,
            Y = player.y
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        Velocity = SplashKit.VectorMultiply(dir, SPEED);
    }

    public abstract void Draw();

    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    public bool IsOffScreen(Window gameWindow)
    {
        return (X < -Width || X > gameWindow.Width || Y < -Height || Y > gameWindow.Height);
    }
}