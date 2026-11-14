using SistemaPacientes.Application.DTOs;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
    public abstract class CrudService<TEntity, TDto> : ICrudService<TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IRepository<TEntity> _repo;
        private readonly Func<TEntity, TDto> _toDto;
        private readonly Func<TDto, TEntity> _toEntity;

        protected CrudService(
            IRepository<TEntity> repo,
            Func<TEntity, TDto> toDto,
            Func<TDto, TEntity> toEntity)
        {
            _repo = repo;
            _toDto = toDto;
            _toEntity = toEntity;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var lista = await _repo.GetAllAsync();
            return lista.Select(_toDto).ToList();
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entidad = await _repo.GetByIdAsync(id);
            return entidad is null ? null : _toDto(entidad);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entidad = _toEntity(dto);
            typeof(TEntity).GetProperty("Id")?.SetValue(entidad, 0);
            var creada = await _repo.AddAsync(entidad);
            return _toDto(creada);
        }

        public async Task<bool> UpdateAsync(int id, TDto dto)
        {
            var existente = await _repo.GetByIdAsync(id);
            if (existente is null) return false;

            CopiarValores(_toEntity(dto), existente);
            await _repo.UpdateAsync(existente);
            return true;
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

        private static void CopiarValores(TEntity origen, TEntity destino)
        {
            foreach (var p in typeof(TEntity).GetProperties())
            {
                if (!p.CanRead || !p.CanWrite || p.Name == "Id") continue;

                var tipo = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                if (tipo.IsPrimitive || tipo == typeof(string) ||
                    tipo == typeof(decimal) || tipo == typeof(DateTime))
                {
                    p.SetValue(destino, p.GetValue(origen));
                }
            }
        }
    }

    public class PacienteService : CrudService<Paciente, PacienteDto>, IPacienteService
    {
        public PacienteService(IRepository<Paciente> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class MedicoService : CrudService<Medico, MedicoDto>, IMedicoService
    {
        public MedicoService(IRepository<Medico> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class EspecialidadService : CrudService<Especialidad, EspecialidadDto>, IEspecialidadService
    {
        public EspecialidadService(IRepository<Especialidad> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class ConsultorioService : CrudService<Consultorio, ConsultorioDto>, IConsultorioService
    {
        public ConsultorioService(IRepository<Consultorio> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class CitaService : CrudService<Cita, CitaDto>, ICitaService
    {
        public CitaService(IRepository<Cita> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class HistoriaClinicaService : CrudService<HistoriaClinica, HistoriaClinicaDto>, IHistoriaClinicaService
    {
        public HistoriaClinicaService(IRepository<HistoriaClinica> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class DiagnosticoService : CrudService<Diagnostico, DiagnosticoDto>, IDiagnosticoService
    {
        public DiagnosticoService(IRepository<Diagnostico> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class TratamientoService : CrudService<Tratamiento, TratamientoDto>, ITratamientoService
    {
        public TratamientoService(IRepository<Tratamiento> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class MedicamentoService : CrudService<Medicamento, MedicamentoDto>, IMedicamentoService
    {
        public MedicamentoService(IRepository<Medicamento> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class RecetaService : CrudService<Receta, RecetaDto>, IRecetaService
    {
        public RecetaService(IRepository<Receta> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }

    public class RecetaDetalleService : CrudService<RecetaDetalle, RecetaDetalleDto>, IRecetaDetalleService
    {
        public RecetaDetalleService(IRepository<RecetaDetalle> repo)
            : base(repo, e => e.ToDto(), d => d.ToEntity()) { }
    }
}