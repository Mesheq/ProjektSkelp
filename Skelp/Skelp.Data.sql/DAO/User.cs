using System;
using System.Collections.Generic;

namespace Skelp.Data.Sql.DAO;

public class User
{
   
    public User()
    {
        Orders = new List<Order>();
        Complains = new List<Complain>();
    }

    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string Email { get; set; }

    public bool IsBannedUser { get; set; }

    public int PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime BirthDate { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Complain> Complains { get; set; }
}