namespace merges;

public class Game
{
    public List<Cell> Cells { get; set; }
    public bool Running { get; set; }
    public int SelectionX { get; set; }
    public int SelectionY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Game()
    {
        Cells = [];
        for (int i = 0; i < 4; i++)
        {
            Cells.Add(new Cell(i + 1, i, i));
        }
        Running = true;
        SelectionX = 0;
        SelectionY = 0;
        Width = 4;
        Height = 4;
    }
    public void Run()
    {
        Console.CursorVisible = false;
        while (Running)
        {
            PrintMap();
            HandleKey();
            HandleLogic();
        }
        Console.CursorVisible = true;
    }
    void HandleLogic()
    {

    }
    void SpawnNewCell()
    {
        if (Cells.Count != Width * Height)
        {
        again:
            var x = Random.Shared.Next(Width);
            var y = Random.Shared.Next(Height);
            if (Cells.Any(c => c.X == x && c.Y == y))
            {
                goto again;
            }
            else
            {
                Cells.Add(new Cell(0, x, y));
            }
        }
    }
    void HandleKey()
    {
        var ki = Console.ReadKey(true);
        var key = ki.Key;
        switch (key)
        {
            case ConsoleKey.Q:
                Running = false;
                break;
            case ConsoleKey.Spacebar:
                SpawnNewCell();
                break;
            case ConsoleKey.A:
            case ConsoleKey.H:
                SelectionX--;
                if (SelectionX < 0)
                    SelectionX = Width - 1;
                break;
            case ConsoleKey.D:
            case ConsoleKey.L:
                SelectionX++;
                if (SelectionX > Width - 1)
                    SelectionX = 0;
                break;
            case ConsoleKey.S:
            case ConsoleKey.J:
                SelectionY++;
                if (SelectionY > Height - 1)
                    SelectionY = 0;
                break;
            case ConsoleKey.W:
            case ConsoleKey.K:
                SelectionY--;
                if (SelectionY < 0)
                    SelectionY = Height - 1;
                break;
        }
    }
    void PrintMap()
    {
        Console.Clear();
        foreach (var cell in Cells)
        {
            cell.Draw(false);
        }
        var selCell = new Cell(-1, SelectionX, SelectionY);
        selCell.Draw(true);
    }
}
