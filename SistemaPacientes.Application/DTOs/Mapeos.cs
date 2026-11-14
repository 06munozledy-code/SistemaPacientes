using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Application.DTOs
{
    public static class Mapeos
    {
        // ---------- Especialidad ----------
        public static EspecialidadDto ToDto(this Especialidad e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Descripcion = e.Descripcion
        };
        public static Especialidad ToEntity(this EspecialidadDto d) => new()
        {
            Id = d.Id,
            Nombre = d.Nombre,
            Descripcion = d.Descripcion
        };

        // ---------- Medico ----------
        public static MedicoDto ToDto(this Medico e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Exequatur = e.Exequatur,
            Telefono = e.Telefono,
            Correo = e.Correo,
            EspecialidadId = e.EspecialidadId
        };
        public static Medico ToEntity(this MedicoDto d) => new()
        {
            Id = d.Id,
            Nombre = d.Nombre,
            Apellido = d.Apellido,
            Exequatur = d.Exequatur,
            Telefono = d.Telefono,
            Correo = d.Correo,
            EspecialidadId = d.EspecialidadId
        };

        // ---------- Consultorio ----------
        public static ConsultorioDto ToDto(this Consultorio e) => new()
        {
            Id = e.Id,
            Numero = e.Numero,
            Ubicacion = e.Ubicacion,
            Activo = e.Activo
        };
        public static Consultorio ToEntity(this ConsultorioDto d) => new()
        {
            Id = d.Id,
            Numero = d.Numero,
            Ubicacion = d.Ubicacion,
            Activo = d.Activo
        };

        // ---------- Paciente ----------
        public static PacienteDto ToDto(this Paciente e) => new()
        {
            Id = e.Id,
            Cedula = e.Cedula,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            FechaNacimiento = e.FechaNacimiento,
            Sexo = e.Sexo,
            Telefono = e.Telefono,
            Correo = e.Correo,
            Direccion = e.Direccion
        };
        public static Paciente ToEntity(this PacienteDto d) => new()
        {
            Id = d.Id,
            Cedula = d.Cedula,
            Nombre = d.Nombre,
            Apellido = d.Apellido,
            FechaNacimiento = d.FechaNacimiento,
            Sexo = d.Sexo,
            Telefono = d.Telefono,
            Correo = d.Correo,
            Direccion = d.Direccion
        };

        // ---------- Cita ----------
        public static CitaDto ToDto(this Cita e) => new()
        {
            Id = e.Id,
            PacienteId = e.PacienteId,
            MedicoId = e.MedicoId,
            ConsultorioId = e.ConsultorioId,
            FechaHora = e.FechaHora,
            Motivo = e.Motivo,
            Estado = e.Estado
        };
        public static Cita ToEntity(this CitaDto d) => new()
        {
            Id = d.Id,
            PacienteId = d.PacienteId,
            MedicoId = d.MedicoId,
            ConsultorioId = d.ConsultorioId,
            FechaHora = d.FechaHora,
            Motivo = d.Motivo,
            Estado = d.Estado
        };

        // ---------- HistoriaClinica ----------
        public static HistoriaClinicaDto ToDto(this HistoriaClinica e) => new()
        {
            Id = e.Id,
            PacienteId = e.PacienteId,
            FechaRegistro = e.FechaRegistro,
            Antecedentes = e.Antecedentes,
            Observaciones = e.Observaciones
        };
        public static HistoriaClinica ToEntity(this HistoriaClinicaDto d) => new()
        {
            Id = d.Id,
            PacienteId = d.PacienteId,
            FechaRegistro = d.FechaRegistro,
            Antecedentes = d.Antecedentes,
            Observaciones = d.Observaciones
        };

        // ---------- Diagnostico ----------
        public static DiagnosticoDto ToDto(this Diagnostico e) => new()
        {
            Id = e.Id,
            HistoriaClinicaId = e.HistoriaClinicaId,
            Descripcion = e.Descripcion,
            Fecha = e.Fecha
        };
        public static Diagnostico ToEntity(this DiagnosticoDto d) => new()
        {
            Id = d.Id,
            HistoriaClinicaId = d.HistoriaClinicaId,
            Descripcion = d.Descripcion,
            Fecha = d.Fecha
        };

        // ---------- Tratamiento ----------
        public static TratamientoDto ToDto(this Tratamiento e) => new()
        {
            Id = e.Id,
            DiagnosticoId = e.DiagnosticoId,
            Descripcion = e.Descripcion,
            FechaInicio = e.FechaInicio,
            DuracionDias = e.DuracionDias
        };
        public static Tratamiento ToEntity(this TratamientoDto d) => new()
        {
            Id = d.Id,
            DiagnosticoId = d.DiagnosticoId,
            Descripcion = d.Descripcion,
            FechaInicio = d.FechaInicio,
            DuracionDias = d.DuracionDias
        };

        // ---------- Medicamento ----------
        public static MedicamentoDto ToDto(this Medicamento e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Presentacion = e.Presentacion,
            Concentracion = e.Concentracion,
            Stock = e.Stock,
            Precio = e.Precio
        };
        public static Medicamento ToEntity(this MedicamentoDto d) => new()
        {
            Id = d.Id,
            Nombre = d.Nombre,
            Presentacion = d.Presentacion,
            Concentracion = d.Concentracion,
            Stock = d.Stock,
            Precio = d.Precio
        };

        // ---------- Receta ----------
        public static RecetaDto ToDto(this Receta e) => new()
        {
            Id = e.Id,
            TratamientoId = e.TratamientoId,
            MedicoId = e.MedicoId,
            Fecha = e.Fecha,
            Notas = e.Notas
        };
        public static Receta ToEntity(this RecetaDto d) => new()
        {
            Id = d.Id,
            TratamientoId = d.TratamientoId,
            MedicoId = d.MedicoId,
            Fecha = d.Fecha,
            Notas = d.Notas
        };

        // ---------- RecetaDetalle ----------
        public static RecetaDetalleDto ToDto(this RecetaDetalle e) => new()
        {
            Id = e.Id,
            RecetaId = e.RecetaId,
            MedicamentoId = e.MedicamentoId,
            Dosis = e.Dosis,
            Frecuencia = e.Frecuencia,
            DuracionDias = e.DuracionDias,
            Cantidad = e.Cantidad,
            Indicaciones = e.Indicaciones
        };
        public static RecetaDetalle ToEntity(this RecetaDetalleDto d) => new()
        {
            Id = d.Id,
            RecetaId = d.RecetaId,
            MedicamentoId = d.MedicamentoId,
            Dosis = d.Dosis,
            Frecuencia = d.Frecuencia,
            DuracionDias = d.DuracionDias,
            Cantidad = d.Cantidad,
            Indicaciones = d.Indicaciones
        };
    }
}