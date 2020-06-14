using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentBoats.Model.User
{
    public class ModelRentBoat
    {
        public int BoatId { get; set; }
        [Required(ErrorMessage = "Please Enter Base Charges")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int BaseCharges { get; set; }

        [Required(ErrorMessage = "Please Enter Hourly Charges")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int HourlyRate { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string CustomerName { get; set; }
        public int Id { get; set; }
        public string RentId { get; set; }
    }
}
