using Microsoft.AspNetCore.Identity;

namespace TaskForLogix.Data
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{this.FirstName} {this.LastName}"; }
            set { }
        }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool PasswordConfirmed { get; set;}
    }
}
