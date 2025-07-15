using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(10)]
        public string Phone { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}
