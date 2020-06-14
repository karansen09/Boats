using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentBoats.Model.User
{
    public class ModelRegisterNewUser
    {
        [Required(ErrorMessage ="Please Enter First Name")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [StringLength(30, ErrorMessage = "Pass \"{0}\" must have no less {2} chars.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]        
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
