using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
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
