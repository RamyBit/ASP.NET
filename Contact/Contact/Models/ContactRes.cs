using System.ComponentModel.DataAnnotations;
namespace Contact.Models
{
    public class ContactRes
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }
    }
}
