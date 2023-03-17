using System;
using System.ComponentModel.DataAnnotations;


namespace Skelp.Api.BindingModels
{
    public class EditUser
    {
      
        [Display(Name = "Username")]
        public string FirstName { get; set; }

        
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
  
      

    }
}