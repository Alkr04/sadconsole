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

    //console1
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
    console1.FocusOnMouseClick = true;

    container.Children.Add(console1);

    //child surface
    ScreenSurface surfaceobject = new(5, 3);
    surfaceobject.Surface.FillWithRandomGarbage(surfaceobject.Font);
    surfaceobject.Position = console1.Surface.Area.Center - (surfaceobject.Surface.Area.Size / 2);
    surfaceobject.UseMouse = false;

    console1.Children.Add(surfaceobject);

    //console2
    Console console2 = new Console(58, 12);
    console2.Position = new Point(19, 11);
    console2.Surface.DefaultBackground = Color.AnsiRed;
    console2.Clear();
    console2.Print(1, 1, "Type on me!");
    console2.Cursor.Position = new Point(1, 2);
    console2.Cursor.IsEnabled = true;
    console2.Cursor.IsVisible = true;
    console2.FocusOnMouseClick = true;
    console2.MoveToFrontOnMouseClick = true;

    container.Children.Add(console2);
    container.Children.MoveToBottom(console2);

}