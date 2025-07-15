using EmpManagementSystem.Data;
using EmpManagementSystem.DTOs;
using EmpManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpManagementSystem.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDto { Id = d.Id, Name = d.Name })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(CreateDepartmentDto dto)
        {
            var department = new Department { Name = dto.Name };
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }

        public async Task<bool> UpdateAsync(int id, CreateDepartmentDto dto)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            dept.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
