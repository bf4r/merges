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

        var startX = X * Width + X;
        var startY = Y * Height + Y;
        Console.SetCursorPosition(startX, startY);
        Console.Write('┌');
        Console.Write(new string('─', Width - 2));
        Console.Write('┐');
        for (int i = 1; i < Height; i++)
        {
            Console.SetCursorPosition(startX, startY + i);
            Console.Write('│');
        }
        for (int i = 1; i < Height; i++)
        {
            Console.SetCursorPosition(startX + Width - 1, startY + i);
            Console.Write('│');
        }
        Console.SetCursorPosition(startX, startY + Height);
        Console.Write('└');
        Console.Write(new string('─', Width - 2));
        Console.Write('┘');
        if (!selected)
        {
            var levelText = Level.ToString();
            Console.SetCursorPosition(startX + Width / 2 - levelText.Length / 2, startY + Height / 2);
            Console.Write(levelText);
        }
    }
}
