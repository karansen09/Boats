using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentBoats.Model.User
{
    public class AddBoat
    {
        public IFormFile BoatImage { get; set; }

        public class AddBoatDetails
        {
            [Required(ErrorMessage ="Please upload image")]
            public IFormFile BoatImage { get; set; }
            [Required(ErrorMessage = "Please Enter Boat Name")]
            
            public string BoatName { get; set; }

            [Required(ErrorMessage = "Please Enter Base Charges")]
            [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
            [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
            public int BaseCharges { get; set; }

            [Required(ErrorMessage = "Please Enter Hourly Charges")]
            [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
            [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
            public int HourlyRate { get; set; }

            public int UserId { get; set; }
            public string BoatImagePath { get; set; }

            public bool IsAvailableForRent { get; set; } = false;
            public int Id { get; set; }
            public string BoatNumber { get; set; }
            public string CustomerName { get; set; }
            public DateTime? RentOutDate { get; set; }
            public DateTime? CreateDate { get; set; }
            public string RentId { get; set; }
        }
    }
}
