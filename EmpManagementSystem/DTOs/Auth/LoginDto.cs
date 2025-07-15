using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.DTOs.Auth
{
    public class LoginDto
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
