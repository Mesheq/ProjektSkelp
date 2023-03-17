using System.Threading.Tasks;

namespace Skelp.IData.User
{
    public interface IUserRepository
    {
        Task<int> AddUser(Skelp.Domain.User.User user);
        Task<Skelp.Domain.User.User> GetUser(int userId);
        Task<Skelp.Domain.User.User> GetUser(string firstName);

        Task RemoveUser(Domain.User.User user);

        
        Task EditUser(Domain.User.User user);
    }
}