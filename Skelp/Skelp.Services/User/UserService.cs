using System.Threading.Tasks;
using Skelp.IData.User;
using Skelp.IServices.Requests;
using Skelp.IServices.User;

namespace Skelp.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Domain.User.User> GetUserByUserId(int userId)
        {
            return _userRepository.GetUser(userId);
        }

        public Task<Domain.User.User> GetUserByUserName(string firstName)
        {
            return _userRepository.GetUser(firstName);
        }

        public async Task<Domain.User.User> CreateUser(CreateUser createUser)
        {
            var user = new Domain.User.User(createUser.FirstName, createUser.LastName, createUser.Email,  createUser.BirthDate, createUser.PhoneNumber);
            user.UserId = await _userRepository.AddUser(user);
            return user;
        }

        public async Task EditUser(EditUser createUser, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            user.EditUser(createUser.FirstName, createUser.LastName, createUser.Email, createUser.PhoneNumber);
            await _userRepository.EditUser(user);
        }
    
    public async Task RemoveUser(int userId)
    {
        var user = await _userRepository.GetUser(userId);
        await _userRepository.RemoveUser(user);
    }
}
}