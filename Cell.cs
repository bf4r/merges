namespace merges;

public class Cell
{
    public const int Width = 10;
    public const int Height = 4;
    public int Level { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Cell(int level, int x, int y)
    {
        Level = level;
        X = x;
        Y = y;
    }

    public void Draw(bool selected = false)
    {
        if (selected)
            Console.ForegroundColor = ConsoleColor.Cyan;
        else
            Console.ForegroundColor = ConsoleColor.White;

        Console.SetCursorPosition(X * Width, Y * Height);
        Console.Write(new string('-', Width));
        for (int i = 1; i < Height; i++)
        {
            Console.SetCursorPosition(X * Width, Y * Height + i);
            Console.Write('|');
        }
        for (int i = 1; i < Height; i++)
        {
            Console.SetCursorPosition(X * Width + Width - 1, Y * Height + i);
            Console.Write('|');
        }
        Console.SetCursorPosition(X * Width, Y * Height + Height);
        Console.Write(new string('-', Width));

        if (!selected)
        {
            var levelText = Level.ToString();
            Console.SetCursorPosition(X * Width + Width / 2 - levelText.Length / 2, Y * Height + Height / 2);
            Console.Write(levelText);
        }
    }
}
