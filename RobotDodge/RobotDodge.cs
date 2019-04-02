using System;
using SplashKitSDK;

public class RobotDodge
{

    private Player _player;

    private Window _gameWindow;
    private Robot _TestRobot;

    public bool Quit
    {
        get
        {
            return _player.Quit;
        }
    }

    public RobotDodge(Window gameWindow)
    {
        _gameWindow = gameWindow;
        _player = new Player(_gameWindow);
        RandomRobot(gameWindow);
    }

    public void HandelInput()
    {
        _player.HandleInput();
        _player.StayOnWindow(_gameWindow);
    }
    public void Draw()
    {
        _gameWindow.Clear(Color.White);
        _TestRobot.Draw();
        _player.Draw();
        _gameWindow.Refresh(60);
    }

    public void Update()
    {
        
    }

    public Robot RandomRobot(Window _gameWindow)
    {
        _TestRobot = new Robot(_gameWindow);

        return _TestRobot;
    }
}