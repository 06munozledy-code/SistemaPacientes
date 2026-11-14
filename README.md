# Sistema de Pacientes

API REST en .NET 8 con arquitectura en capas y Entity Framework Core, consumida por un frontend en React (Vite).

## Arquitectura

- **Domain**: entidades e interfaces (`IRepository<T>`).
- **Application**: DTOs, mapeos, interfaces (`ICrudService<TDto>` y una por entidad) y servicios.
- **Infrastructure**: `AppDbContext`, repositorios y migraciones.
- **API**: controladores CRUD.
- **frontend**: aplicación React que consume la API.

## Entidades (11 tablas)

Paciente, Medico, Especialidad, Consultorio, Cita, HistoriaClinica, Diagnostico, Tratamiento, Medicamento, Receta, RecetaDetalle.

## Cómo ejecutarlo

1. Abrir la solución en Visual Studio 2022.
2. Aplicar migraciones: `Update-Database` (proyecto Infrastructure, inicio API).
3. Ejecutar `SistemaPacientes.API` (https://localhost:7130).
4. En la carpeta `frontend`: `npm install` y `npm run dev`.
5. Abrir http://localhost:5173.

## Tecnologías

.NET 8, Entity Framework Core, SQL Server (LocalDB), React, Vite.

## Conceptos de N capas aplicados

- **Separación en capas**: Domain, Application, Infrastructure y API, con dependencias en una sola dirección.
- **Interfaces**: `IRepository<T>` (Domain) e `ICrudService<TDto>` con una interfaz por entidad (Application).
- **Patrón Repositorio**: `Repository<T>` en Infrastructure.
- **DTOs y mapeos**: la API nunca expone las entidades directamente.
- **Capa de servicios**: la lógica de negocio vive en Application.
- **Inyección de dependencias**: todo se registra en `Program.cs`.
- **Entity Framework Core con migraciones**: 11 tablas en SQL Server.
- **Frontend desacoplado**: React consume la API REST.
