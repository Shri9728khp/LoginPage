using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginPage.Models
{
    public class EmpData
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string Practice_Field { get; set; }
        [Required(ErrorMessage = "Please Fill this Field")]
        public string Role { get; set; }
    }
}