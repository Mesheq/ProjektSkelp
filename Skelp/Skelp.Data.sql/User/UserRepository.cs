using System.Net;
using System.Threading.Tasks;
using Skelp.IData.User;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Skelp.Data.Sql.User
{
    public class UserRepository : IUserRepository
    {
        private readonly SkelpDbContext _context;

        public UserRepository(SkelpDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(Domain.User.User user)
        {
            var userDAO = new DAO.User
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
                PhoneNumber = user.PhoneNumber,
                IsBannedUser = user.IsBannedUser,

            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }

        public async Task<Domain.User.User> GetUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return new Domain.User.User(user.UserId,
                user.FirstName,
                user.LastName,
                user.Email,
                user.BirthDate,
                user.IsBannedUser,
                user.PhoneNumber,
                user.RegistrationDate);
        }

        public async Task<Domain.User.User> GetUser(string firstName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.FirstName == firstName);
            return new Domain.User.User(user.UserId,
                user.FirstName,
                user.LastName,
                user.Email,
                user.BirthDate,
                user.IsBannedUser,
                user.PhoneNumber,
                user.RegistrationDate);
        }

        public async Task EditUser(Domain.User.User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == user.UserId);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Email = user.Email;
            editUser.PhoneNumber = user.PhoneNumber;
            editUser.BirthDate = user.BirthDate;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveUser(Domain.User.User user)
        {
            var loop = true;
            do
            {
                var DeleteOrder = await _context.Order.FirstOrDefaultAsync(n => n.UserId == user.UserId);
                if (DeleteOrder != null)
                {
                    _context.Order.Remove(DeleteOrder);
                }
                else
                {
                    loop = false;
                }

                await _context.SaveChangesAsync();
            } while (loop);
            
            var RemoveComplain =   await _context.Complain.FirstOrDefaultAsync(n => n.UserId == user.UserId);
            if (RemoveComplain != null)
            {
                _context.Complain.Remove((RemoveComplain));
            }

            var removeuser = await _context.User.FirstOrDefaultAsync(n => n.UserId == user.UserId);
            if (removeuser != null)
            {
                _context.User.Remove(removeuser);
            }

            await _context.SaveChangesAsync();

        }

    }
}

