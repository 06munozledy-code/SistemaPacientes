using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<T>> GetAllAsync() => _repository.GetAllAsync();

        public Task<T?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<T> CreateAsync(T entity) => _repository.AddAsync(entity);

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing is null) return false;

            typeof(T).GetProperty("Id")?.SetValue(entity, id);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}