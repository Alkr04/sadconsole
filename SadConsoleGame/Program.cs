using SadConsole;
using SadConsole.Configuration;

Settings.WindowTitle = "My SadConsole Game";

Builder configuration = new Builder()
    .SetScreenSize(90, 30)
    .OnStart(Startup)
    ;

Game.Create(configuration);
Game.Instance.Run();
Game.Instance.Dispose();

static void Startup(object? sender, GameHost host)
{
    ScreenObject container = new ScreenObject();
    Game.Instance.Screen = container;

    Console console1 = new(60, 14);
    console1.Position = (3, 2);
    console1.Surface.DefaultBackground = Color.AnsiCyan;
    console1.Clear();
    console1.Print(1, 1, "type on me!");
    console1.Cursor.Position = (1, 2);
    console1.Cursor.IsEnabled = true;
    console1.Cursor.IsVisible = true;
    console1.Cursor.MouseClickReposition = true;
    console1.IsFocused = true;

    container.Children.Add(console1);

    ScreenSurface surfaceobject = new(5, 3);
    surfaceobject.Surface.FillWithRandomGarbage(surfaceobject.Font);
    surfaceobject.Position = console1.Surface.Area.Center - (surfaceobject.Surface.Area.Size / 2);
    surfaceobject.UseMouse = false;

    console1.Children.Add(surfaceobject);
}