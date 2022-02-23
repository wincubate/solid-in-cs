using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    // Violates LSP Contract Rule:
    // Strengthened precondition: Width == Height
    class Square : Rectangle
    {
        public Square(int size) : base(size, size)
        {
        }
    }
}
