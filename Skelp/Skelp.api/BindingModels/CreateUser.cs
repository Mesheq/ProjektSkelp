using System;
using System.ComponentModel.DataAnnotations;

namespace Skelp.Api.BindingModels
{
    public class CreateUser
    {
        [Required]
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display (Name = "LastName")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name= "PhoneNumber")]
        public string PhoneNumber { get; set; }
        
        
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
       
        
     
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

    }
}