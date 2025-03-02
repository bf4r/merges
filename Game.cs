namespace merges;

public class Game
{
    public List<Cell> Cells { get; set; }
    public bool Running { get; set; }
    public Game()
    {
        Cells = [];
        for (int i = 0; i < 4; i++)
        {
            Cells.Add(new Cell(i + 1, i, i));
        }
        Running = true;
    }
    public void Run()
    {
        Console.CursorVisible = false;
        while (Running)
        {
            PrintMap();
            HandleKey();
        }
        Console.CursorVisible = true;
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
        }
    }
    void PrintMap()
    {
        Console.Clear();
        foreach (var cell in Cells)
        {
            cell.Draw();
        }
    }
}
