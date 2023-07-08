using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test_dotnet.Models
{
    public class User
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The PhoneNumber field is required.")]
        [RegularExpression(@"^(\+)?\d+$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The State field is required.")]
        public string State { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public List<string> States { get; set; }
    }
}
