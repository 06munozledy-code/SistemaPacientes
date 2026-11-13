using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<Medico> Medicos => Set<Medico>();
        public DbSet<Especialidad> Especialidades => Set<Especialidad>();
        public DbSet<Consultorio> Consultorios => Set<Consultorio>();
        public DbSet<Cita> Citas => Set<Cita>();
        public DbSet<HistoriaClinica> HistoriasClinicas => Set<HistoriaClinica>();
        public DbSet<Diagnostico> Diagnosticos => Set<Diagnostico>();
        public DbSet<Tratamiento> Tratamientos => Set<Tratamiento>();
        public DbSet<Medicamento> Medicamentos => Set<Medicamento>();
        public DbSet<Receta> Recetas => Set<Receta>();
        public DbSet<RecetaDetalle> RecetaDetalles => Set<RecetaDetalle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evita el error de "múltiples rutas de cascada" en SQL Server
            foreach (var fk in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Precisión por defecto para propiedades decimal (precios, etc.)
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }
    }
}