using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBall.Models;
using System.ComponentModel.DataAnnotations;

namespace BlackBall.Models
{
    public class RegistrationViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Mobile phone number is required")]
        [RegularExpression(@"07\d{9}", ErrorMessage="A UK mobile phone number should start with 07 followed by 9 other digits")]
        public string MobilePhoneNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (this.Password != this.PasswordConfirmation)
            {
                yield return new ValidationResult("Passwords must match", new string[] { "Password", "PasswordConfirmation" });
            }

            BlackBallDatabase db = new BlackBallDatabase();
            if (db.Users.Any(x => x.EmailAddress==EmailAddress))
            {
                yield return new ValidationResult("Email address is already registered", new string[] { "EmailAddress" });
            }
        }

        public User ToUser()
        {
            return new User
            {
                Name=this.Name,
                EmailAddress=this.EmailAddress,
                Password=this.Password, // should hash and salt
                MobilePhoneNumber=this.MobilePhoneNumber
            };
        }
    }
}
