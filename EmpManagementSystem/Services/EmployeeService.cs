using EmpManagementSystem.Data;
using EmpManagementSystem.DTOs;
using EmpManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpManagementSystem.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    Phone = e.Phone,
                })
                .ToListAsync();
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var e = await _context.Employees
                .Include(d => d.Department)
                .Include(d => d.Designation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (e == null) return null;

            return new EmployeeDto
            {
                Id = e.Id,
                FullName = e.FullName,
                Email = e.Email,
                Phone = e.Phone,
            };
        }
        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
                DesignationId = dto.DesignationId
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<bool> UpdateAsync(int id, CreateEmployeeDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            employee.FullName = dto.FullName;
            employee.Email = dto.Email;
            employee.Phone = dto.Phone;
            employee.DepartmentId = dto.DepartmentId;
            employee.DesignationId = dto.DesignationId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
