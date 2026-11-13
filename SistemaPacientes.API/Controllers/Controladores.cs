using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.API.Controllers
{
    public class PacientesController : BaseController<Paciente>
    { public PacientesController(IService<Paciente> s) : base(s) { } }

    public class MedicosController : BaseController<Medico>
    { public MedicosController(IService<Medico> s) : base(s) { } }

    public class EspecialidadesController : BaseController<Especialidad>
    { public EspecialidadesController(IService<Especialidad> s) : base(s) { } }

    public class ConsultoriosController : BaseController<Consultorio>
    { public ConsultoriosController(IService<Consultorio> s) : base(s) { } }

    public class CitasController : BaseController<Cita>
    { public CitasController(IService<Cita> s) : base(s) { } }

    public class HistoriasClinicasController : BaseController<HistoriaClinica>
    { public HistoriasClinicasController(IService<HistoriaClinica> s) : base(s) { } }

    public class DiagnosticosController : BaseController<Diagnostico>
    { public DiagnosticosController(IService<Diagnostico> s) : base(s) { } }

    public class TratamientosController : BaseController<Tratamiento>
    { public TratamientosController(IService<Tratamiento> s) : base(s) { } }

    public class MedicamentosController : BaseController<Medicamento>
    { public MedicamentosController(IService<Medicamento> s) : base(s) { } }

    public class RecetasController : BaseController<Receta>
    { public RecetasController(IService<Receta> s) : base(s) { } }

    public class RecetaDetallesController : BaseController<RecetaDetalle>
    { public RecetaDetallesController(IService<RecetaDetalle> s) : base(s) { } }
}