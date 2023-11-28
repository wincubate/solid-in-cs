using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

// Violates LSP Contract Rule:
// Strengthened precondition: Width == Height
record class Square : Rectangle
{
    public Square(int size) : base(size, size)
    {
    }
}
