using System;
using Skelp.Domain.DomainExceptions;

namespace Skelp.Domain.User
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsBannedUser { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set;}

        public User(int userId, string firstName, string lastName, string email, DateTime birthDate, bool isBannedUser, int phoneNumber, DateTime registrationDate)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            IsBannedUser = isBannedUser;
            PhoneNumber = phoneNumber;
            RegistrationDate = registrationDate;
        }
        public User( string firstName, string lastName, string email, DateTime birthDate, int phoneNumber)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
           
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            IsBannedUser = false;
            PhoneNumber = phoneNumber;
            RegistrationDate = DateTime.UtcNow;
          
        }
        
        public void EditUser(string firstName, string lastName, string email, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
          
            
        }

    }
}