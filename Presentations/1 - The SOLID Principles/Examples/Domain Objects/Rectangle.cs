namespace Wincubate.Module1.Domain;

public record class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override string ToString() => $"[{Width}x{Height}]";

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
}
