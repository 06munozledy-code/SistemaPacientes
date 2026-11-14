using SistemaPacientes.Application.DTOs;

namespace SistemaPacientes.Application.Interfaces
{
    public interface ICrudService<TDto> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task<bool> UpdateAsync(int id, TDto dto);
        Task<bool> DeleteAsync(int id);
    }

    public interface IPacienteService : ICrudService<PacienteDto> { }
    public interface IMedicoService : ICrudService<MedicoDto> { }
    public interface IEspecialidadService : ICrudService<EspecialidadDto> { }
    public interface IConsultorioService : ICrudService<ConsultorioDto> { }
    public interface ICitaService : ICrudService<CitaDto> { }
    public interface IHistoriaClinicaService : ICrudService<HistoriaClinicaDto> { }
    public interface IDiagnosticoService : ICrudService<DiagnosticoDto> { }
    public interface ITratamientoService : ICrudService<TratamientoDto> { }
    public interface IMedicamentoService : ICrudService<MedicamentoDto> { }
    public interface IRecetaService : ICrudService<RecetaDto> { }
    public interface IRecetaDetalleService : ICrudService<RecetaDetalleDto> { }
}