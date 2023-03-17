using System.Threading.Tasks;
using Skelp.IServices.Requests;

namespace Skelp.IServices.User
{
    public interface IUserService
    {
        Task<Domain.User.User> GetUserByUserId(int userId);
        Task<Domain.User.User> GetUserByUserName(string firstName);
        Task<Domain.User.User> CreateUser(CreateUser createUser);

        Task RemoveUser(int userId);
        Task EditUser(EditUser createUser, int userId);
    }
}