using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodMorningTeam_08102021.Models
{
    public class RegistrationModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password Not Matches")]
        public string ConfirmPassword { get; set; }
        [Range(12,70,ErrorMessage ="12-70 is Only Valid")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="EmailId is not Valid ")]
        public string EmailId { get; set; }
        [StringLength(10,ErrorMessage ="Length should be 10 character")]
        public string Address { get; set; }
    }
}