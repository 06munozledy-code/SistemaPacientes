# Sistema de Pacientes

API REST en .NET 8 con arquitectura en capas y Entity Framework Core, consumida por un frontend en React (Vite).

## Arquitectura

- **Domain**: entidades e interfaces (`IRepository<T>`).
- **Application**: interfaces y servicios (`IService<T>`, `Service<T>`).
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