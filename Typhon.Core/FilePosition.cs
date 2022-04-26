namespace Typhon.Core;

public struct FilePosition
{
    public int Line;
    public int Column;

    public FilePosition(int line, int column)
    {
        Line = line;
        Column = column;
    }

    public static readonly FilePosition Start = new(1, 0);
}
