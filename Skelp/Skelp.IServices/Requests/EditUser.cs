using System;


namespace Skelp.IServices.Requests
{
    public class EditUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        
        public DateTime BirthDate { get; set; }

    }
}