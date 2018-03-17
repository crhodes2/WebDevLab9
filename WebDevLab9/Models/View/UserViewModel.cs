using System;
using System.ComponentModel.DataAnnotations;

namespace WebDevLab9.Models.View
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }
    }
}