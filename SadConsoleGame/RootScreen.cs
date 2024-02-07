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
    private Gameobjekt _controlledobject;
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
            _controlledobject.Move(_controlledobject.Position + Direction.Up, _map.SurfaceObject);
            handeled = false;
        }
        else if (keyboard.IsKeyPressed(Keys.S))
        {
            _controlledobject.Move(_controlledobject.Position + Direction.Down, _map.SurfaceObject);
        }
        if (keyboard.IsKeyPressed(Keys.A))
        {
            _controlledobject.Move(_controlledobject.Position + Direction.Left, _map.SurfaceObject);
        }
        else if (keyboard.IsKeyPressed(Keys.D))
        {
            _controlledobject.Move(_controlledobject.Position + Direction.Right, _map.SurfaceObject);
        }
        return handeled;
    }
}
