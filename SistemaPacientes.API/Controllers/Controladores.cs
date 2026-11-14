using SistemaPacientes.Application.DTOs;
using SistemaPacientes.Application.Interfaces;

namespace SistemaPacientes.API.Controllers
{
    public class PacientesController : BaseController<PacienteDto>
    { public PacientesController(IPacienteService s) : base(s) { } }

    public class MedicosController : BaseController<MedicoDto>
    { public MedicosController(IMedicoService s) : base(s) { } }

    public class EspecialidadesController : BaseController<EspecialidadDto>
    { public EspecialidadesController(IEspecialidadService s) : base(s) { } }

    public class ConsultoriosController : BaseController<ConsultorioDto>
    { public ConsultoriosController(IConsultorioService s) : base(s) { } }

    public class CitasController : BaseController<CitaDto>
    { public CitasController(ICitaService s) : base(s) { } }

    public class HistoriasClinicasController : BaseController<HistoriaClinicaDto>
    { public HistoriasClinicasController(IHistoriaClinicaService s) : base(s) { } }

    public class DiagnosticosController : BaseController<DiagnosticoDto>
    { public DiagnosticosController(IDiagnosticoService s) : base(s) { } }

    public class TratamientosController : BaseController<TratamientoDto>
    { public TratamientosController(ITratamientoService s) : base(s) { } }

    public class MedicamentosController : BaseController<MedicamentoDto>
    { public MedicamentosController(IMedicamentoService s) : base(s) { } }

    public class RecetasController : BaseController<RecetaDto>
    { public RecetasController(IRecetaService s) : base(s) { } }

    public class RecetaDetallesController : BaseController<RecetaDetalleDto>
    { public RecetaDetallesController(IRecetaDetalleService s) : base(s) { } }
}