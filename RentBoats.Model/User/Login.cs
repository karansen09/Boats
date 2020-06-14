using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentBoats.Model.User
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Username")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public string Id { get; set; }
    }
}
