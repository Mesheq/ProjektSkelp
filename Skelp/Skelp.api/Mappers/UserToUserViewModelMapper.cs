using Skelp.Api.ViewModels;

namespace Skelp.Api.Mappers
{
    public class UserToUserViewModelMapper
    {
        public static UserViewModel UserToUserViewModel(Domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate,
                IsBannedUser = user.IsBannedUser

            };
            return userViewModel;
        }

    }
}