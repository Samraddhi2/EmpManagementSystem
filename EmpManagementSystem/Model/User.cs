using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; } // Admin, HR, Employee
    }
}
