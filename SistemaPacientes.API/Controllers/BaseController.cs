using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;

namespace SistemaPacientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        protected readonly IService<T> _service;

        protected BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T entity)
            => Ok(await _service.CreateAsync(entity));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] T entity)
            => await _service.UpdateAsync(id, entity) ? NoContent() : NotFound();

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}