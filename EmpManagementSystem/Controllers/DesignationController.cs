using EmpManagementSystem.DTOs;
using EmpManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DesignationController : ControllerBase
    {
        private readonly DesignationService _service;

        public DesignationController(DesignationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDesignationDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id }, new { message = "Designation created", id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDesignationDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? Ok(new { message = "Designation updated" }) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok(new { message = "Designation deleted" }) : NotFound();
        }
    }
}
