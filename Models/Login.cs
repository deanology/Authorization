using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email address is Required.")]
        [RegularExpression(@"[A-Za-z0-9._%)]+@[A-Za-z0-9,-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        //************************************************//
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
    }
}