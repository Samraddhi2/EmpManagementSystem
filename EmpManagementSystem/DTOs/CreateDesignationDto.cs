using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.DTOs
{
    public class CreateDesignationDto
    {
        [Required, StringLength(100)]
        public string Title { get; set; }
    }
}
