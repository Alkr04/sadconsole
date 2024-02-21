using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Input;

namespace SadConsoleGame;

internal class RootScreen : ScreenObject
{
    private Map  _map;

    public RootScreen()
    {
        _map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 5);

        Children.Add(_map.SurfaceObject);
    }
    
    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handeled = false;
        if (keyboard.IsKeyPressed(Keys.W))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Up, _map);
            handeled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.S))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Down, _map);
            handeled = true;
        }
        if (keyboard.IsKeyPressed(Keys.A))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Left, _map);
            handeled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.D))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Right, _map);
            handeled = true;
        }
        return handeled;
    }
}
