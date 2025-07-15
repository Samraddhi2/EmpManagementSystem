using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.DTOs
{
    public class CreateDepartmentDto
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}
