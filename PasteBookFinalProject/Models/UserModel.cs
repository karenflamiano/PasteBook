using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class UserModel
    {
        [Required]
        [RegularExpression("([ a-zA-Z])*", ErrorMessage = "{0} must not contain any numbers or any special characters.")]
        [StringLength(15, ErrorMessage = "Maximum length for {0} is 15 characters only.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("([a-zA-Z])*", ErrorMessage = "{0} must not contain any numbers or any special characters.")]
        [StringLength(15, ErrorMessage = "Maximum length for {0} is 15 characters only.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} is not a valid email address, email@domain.com.")]
        public string EmailAddress { get; set; }


        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMMM dd,yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }


        public int CountryID { get; set; }


     
        [StringLength(16, MinimumLength = 9, ErrorMessage = "{0} must be between 8 and 15 characters long.")]
        [RegularExpression("[0-9|+][0-9]{8,15}", ErrorMessage = "{0} must follow the specified format. (+63.. or 09..)")]
        public string MobileNumber { get; set; }


        [Required]
        public char Gender { get; set; }

        
        
        [Required]
        [RegularExpression("(?=.{8,})([a-zA-Z0-9])*", ErrorMessage = "{0} must be at least 8 characters long and must not contain any special characters.")]
        [StringLength(30, ErrorMessage = "Username is too long. Maximum of 30 characters.")]
        public string Username { get; set; }
        

        [Required]
        [RegularExpression("^(?=.{8,})(?!.*[ ])(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[_`!%$&^*()]).*$", ErrorMessage = "{0} must be at least 8 characters long and must contain atleast one specialcase character, one lowercase and one uppercase.")]
        [StringLength(15, ErrorMessage = "Maximum length for {0} is 15 characters only.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "{0} do not match the Password typed above.")]
        public string ConfirmPassword { get; set; }

        [StringLength(2000, ErrorMessage = "Maximum length for {0} is 2000 characters only.")]
        public string AboutMe { get; set; }


        public byte[] ProfilePicture { get; set; }



    }
}