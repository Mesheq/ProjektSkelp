using System;


namespace Skelp.Api.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public bool IsBannedUser { get; set; }

        public int PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set;}
   
    }
}