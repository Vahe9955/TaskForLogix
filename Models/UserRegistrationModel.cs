using System.ComponentModel.DataAnnotations;

namespace TaskForLogix.Models
{
    public class UserRegistrationModel
    {
        public Guid UserId { get; set; }

        [Required, MinLength(3)]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }


        [Required, MinLength(3)]
        [Display(Name = "LastName")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "FullName")]
        [DataType(DataType.Text)]
        public string FullName
        {
            get { return $"{this.FirstName} {this.LastName}"; }
        }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
       
        [MaxLength(256)]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }
    
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

     
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
