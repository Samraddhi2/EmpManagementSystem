using EmpManagementSystem.Data;
using EmpManagementSystem.DTOs;
using EmpManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpManagementSystem.Services
{
    public class DesignationService
    {
        private readonly AppDbContext _context;

        public DesignationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            return await _context.Designations
                .Select(d => new DepartmentDto { Id = d.Id, Name = d.Title })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(CreateDesignationDto dto)
        {
            var designation = new Designation { Title = dto.Title };
            _context.Designations.Add(designation); // Fixed: Changed from _context.Departments to _context.Designations
            await _context.SaveChangesAsync();
            return designation.Id;
        }

        public async Task<bool> UpdateAsync(int id, CreateDesignationDto dto)
        {
            var dept = await _context.Designations.FindAsync(id);
            if (dept == null) return false;

            dept.Title = dto.Title;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _context.Designations.FindAsync(id);
            if (dept == null) return false;

            _context.Designations.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
