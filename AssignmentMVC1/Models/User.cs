using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC1.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Name")]
        [StringLength(10,ErrorMessage ="The {0} cannot exceed {1} characters")]
        public string userName { set; get; }
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="The {0} should be of alteast {1} characters")]
        [Required(ErrorMessage ="Please Enter a password")]
        public string password { set; get; }
       /* [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter your full name")]
        public string fullName { set; get; }*/
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter an email address")]
        public string emailId { set; get; }
        [DataType(DataType.Text)]
        public int cityId { set; get; }
        [Required(ErrorMessage ="Please select your city")]
        public IEnumerable<SelectListItem> Cities { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Please enter your phone number")]
        public string phoneNumber { set; get; }
        public bool rememberMe { set; get; }
    }
}