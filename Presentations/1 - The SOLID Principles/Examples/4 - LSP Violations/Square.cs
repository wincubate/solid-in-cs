using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    // Violates LSP Contract Rule:
    // Strengthened precondition: Width == Height
    class Square : Rectangle
    {
        public Square( int size ) : base( size, size )
        {
        }
    }
}
