namespace EmpManagementSystem.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DepartmentId { get; set; }
        public string DesignationId { get; set; }
    }
}
