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
        }
        Console.CursorVisible = true;
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
                Cells.Add(new Cell(1, x, y));
            }
        }
    }
    void HandleKey()
    {
        var ki = Console.ReadKey(true);
        var key = ki.Key;
        var shift = ki.Modifiers == ConsoleModifiers.Shift;
        if (!shift)
        {
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
                case ConsoleKey.LeftArrow:
                    SelectionX--;
                    if (SelectionX < 0)
                        SelectionX = Width - 1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.L:
                case ConsoleKey.RightArrow:
                    SelectionX++;
                    if (SelectionX > Width - 1)
                        SelectionX = 0;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.J:
                case ConsoleKey.DownArrow:
                    SelectionY++;
                    if (SelectionY > Height - 1)
                        SelectionY = 0;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.K:
                case ConsoleKey.UpArrow:
                    SelectionY--;
                    if (SelectionY < 0)
                        SelectionY = Height - 1;
                    break;
            }
        }
        else
        {
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.H:
                case ConsoleKey.LeftArrow:
                    Merge(-1, 0);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.L:
                case ConsoleKey.RightArrow:
                    Merge(1, 0);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.J:
                case ConsoleKey.DownArrow:
                    Merge(0, 1);
                    break;
                case ConsoleKey.W:
                case ConsoleKey.K:
                case ConsoleKey.UpArrow:
                    Merge(0, -1);
                    break;
            }
        }
    }
    void Merge(int offsetX, int offsetY)
    {
        var cell = Cells.FirstOrDefault(c => c.X == SelectionX && c.Y == SelectionY);
        var targetX = SelectionX + offsetX;
        var targetY = SelectionY + offsetY;
        if (targetX > Width - 1)
            targetX = 0;
        if (targetX < 0)
            targetX = Width - 1;
        if (targetY > Height - 1)
            targetY = 0;
        if (targetY < 0)
            targetY = Height - 1;
        if (cell == null)
        {
            SelectionX = targetX;
            SelectionY = targetY;
            return;
        }
        var otherCell = Cells.FirstOrDefault(c => c.X == targetX && c.Y == targetY);
        if (otherCell == null)
        {
            // move it
            cell.X = targetX;
            cell.Y = targetY;
            SelectionX = cell.X;
            SelectionY = cell.Y;
            return;
        }
        if (otherCell.Level == cell.Level)
        {
            Cells.Remove(cell);
            Cells.Remove(otherCell);
            var newCell = new Cell(cell.Level + 1, targetX, targetY);
            Cells.Add(newCell);
            SelectionX = newCell.X;
            SelectionY = newCell.Y;
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
