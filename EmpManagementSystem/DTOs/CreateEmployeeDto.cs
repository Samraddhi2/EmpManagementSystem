using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.DTOs
{
    public class CreateEmployeeDto
    {
        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(10)]
        public string Phone { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int DesignationId { get; set; }
    }
}
