namespace merges;

class Cell
{
    public int Level { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Cell(int level, int x, int y)
    {
        Level = level;
        X = x;
        Y = y;
    }

    public void Draw()
    {
        var width = 10;
        var height = 5;
        Console.SetCursorPosition(X * width, Y * height);
        Console.Write('s');
    }
}
