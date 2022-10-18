using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string IIN { get; set; }
    }
}
