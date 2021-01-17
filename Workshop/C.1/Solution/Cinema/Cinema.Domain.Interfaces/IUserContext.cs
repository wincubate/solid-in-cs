namespace Cinema.Domain.Interfaces
{
    public interface IUserContext
    {
        bool IsInRole(UserRole role);
    }
}
