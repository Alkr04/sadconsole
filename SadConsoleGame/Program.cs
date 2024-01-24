using SadConsole;
using SadConsole.Configuration;

Settings.WindowTitle = "My SadConsole Game";

Game.Create(90, 30, Startup);
Game.Instance.Run();
Game.Instance.Dispose();

static void Startup(object? sender, GameHost host)
{

    Console StartingConsole = Game.Instance.StartingConsole!;

    //StartingConsole.FillWithRandomGarbage(SadConsole.Game.Instance.StartingConsole!.Font);
    StartingConsole.Fill(new Rectangle(3, 3, 23, 3), Color.Violet, Color.Black, 0, Mirror.None);
    StartingConsole.Print(4, 4, "Hello from SadConsole");
    //StartingConsole.DrawBox(new Rectangle(3, 3, 23, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Violet, Color.Black, 176)));
    StartingConsole.DrawBox(new Rectangle(3, 3, 23, 3), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThick, new ColoredGlyph(Color.Violet, Color.Black)));
    StartingConsole.DrawCircle(new Rectangle(5, 8, 16, 8), ShapeParameters.CreateFilled(new ColoredGlyph(Color.Violet, Color.Black, 176), new ColoredGlyph(Color.White, Color.Black)));
    StartingConsole.DrawLine(new Point(60, 5), new Point(66, 20), '$', Color.AnsiBlack, Color.AnsiBlueBright, Mirror.None);
    StartingConsole.SetForeground(15, 4, Color.DarkCyan);

}