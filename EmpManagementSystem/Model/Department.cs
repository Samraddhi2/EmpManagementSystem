using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystem.Model
{
    public class Department
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
