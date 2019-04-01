using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("Robot Dodge!", 800, 600);
        Player playerOne = new Player(gameWindow);        


        //SplashKit.Delay(5000);

        while (!SplashKit.QuitRequested() && playerOne.Quit != true)
        {
            gameWindow.Clear(Color.White);
            playerOne.Draw();
            playerOne.HandleInput();
            playerOne.StayOnWindow(gameWindow);
            gameWindow.Refresh(60);
        }
    }
}
