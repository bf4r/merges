namespace merges;

public class Cell
{
    public int Level { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsSelected { get; set; }
    public Cell(int level, int x, int y)
    {
        Level = level;
        X = x;
        Y = y;
        IsSelected = false;
    }

    public void Draw()
    {
        var width = 10;
        var height = 4;
        Console.SetCursorPosition(X * width, Y * height);
        Console.Write(new string('-', width));
        for (int i = 1; i < height; i++)
        {
            Console.SetCursorPosition(X * width, Y * height + i);
            Console.Write('|');
        }
        for (int i = 1; i < height; i++)
        {
            Console.SetCursorPosition(X * width + width - 1, Y * height + i);
            Console.Write('|');
        }
        Console.SetCursorPosition(X * width, Y * height + height);
        Console.Write(new string('-', width));
        var levelText = Level.ToString();
        try
        {
            Console.SetCursorPosition(X * width + width / 2 - levelText.Length / 2, Y * height + height / 2);
            Console.Write(levelText);
        }
        catch (Exception)
        {
        }
    }
}
