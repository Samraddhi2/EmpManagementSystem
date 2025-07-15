using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.DTOs.Auth
{
    public class RegisterDto
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Admin, HR, Employee
    }
}
