namespace merges;

public class Game
{
    List<Cell> Cells { get; set; }
    public Game()
    {
        Cells = [];
        for (int i = 0; i < 4; i++)
        {
            Cells.Add(new Cell(1, i, 0));
        }
    }
    public void Run()
    {
        bool running = true;
        while (running)
        {
            PrintMap();
            Console.ReadKey();
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
