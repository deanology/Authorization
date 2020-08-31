using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class User
    {
            public int UserId { get; set; }
            //************************************************//
            [Required(ErrorMessage = "Fullname is Required.")]
            public string Fullname { get; set; }
            //************************************************//
            [Required(ErrorMessage = "Password is Required.")]
            public string Password { get; set; }
            //************************************************//
            [Required(ErrorMessage = "Confirmed Password is Required.")]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password do not match")]
            public string ConfirmPassword { get; set; }
            //************************************************//
            [Required(ErrorMessage = "Email address is Required.")]
            [RegularExpression(@"[A-Za-z0-9._%)]+@[A-Za-z0-9,-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }
            //************************************************//
            public DateTime RegistrationDate { get; set; }
            //************************************************//
            public Nullable<DateTime> LastLoginDate { get; set; }
        }
    }
