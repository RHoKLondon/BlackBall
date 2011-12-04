using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlackBall.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "You need to enter your name")]
        [Display(Name = "Your name:")]
        public string SendersName { get; set; }

        [Required(ErrorMessage = "You need to enter your email address")]
        [Display(Name = "Your email address:")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Please enter a valid email address")]
        public string SendersEmailAddress { get; set; }

        [Required(ErrorMessage = "You need to type a message")]
        [Display(Name = "Your message:")]
        public string Body { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime RenderTime { get; set; }
    }
}
