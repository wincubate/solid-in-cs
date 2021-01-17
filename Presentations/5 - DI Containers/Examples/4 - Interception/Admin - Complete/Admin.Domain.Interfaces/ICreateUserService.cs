using System.Threading.Tasks;

namespace Admin.Domain.Interfaces
{
    public interface ICreateUserService
    {
        Task CreateUserAsync(User user);
    }
}
