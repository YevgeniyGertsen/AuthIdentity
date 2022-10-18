using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public enum Gender {Female, Male, Other }
    public class AppUser : IdentityUser
    {
        [Required]
        public Gender Gender { get; set; }

        public int Age { get; set; }

        [Required]
        public string IIN { get; set; }
    }
}
