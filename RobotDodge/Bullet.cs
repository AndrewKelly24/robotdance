using System;
using SplashKitSDK;

public class Bullet
{

    public double X { get; private set; }
    public double Y { get; private set; }

    public int Radius
    {
        get { return 10; }
    }

    private const int SPEED = 5;
    private Vector2D Velocity { get; set; }

    public Color BulletColor { get; set; }

    public Circle CollisionCircle
    {
        get { return SplashKit.CircleAt(X, Y, Radius); }
    }

    public Bullet(Window gameWindow, Player player)
    {
        X = player.x + player.Width / 2;
        Y = player.y + player.Height / 2;

        BulletColor = Color.DarkRed;

        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        Point2D toPt = SplashKit.MousePosition();
        


        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        Velocity = SplashKit.VectorMultiply(dir, SPEED);
    }

    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    public void Draw()
    {
        SplashKit.FillCircle(BulletColor, X, Y, Radius);
    }

    public bool CollidedWith(Robot robot)
    {
        return SplashKit.CirclesIntersect(CollisionCircle, robot.CollisionCircle);
    }

    public bool IsOffScreen(Window gameWindow)
    {
        return (X < -Radius || X > gameWindow.Width || Y < -Radius || Y > gameWindow.Height);
    }
}