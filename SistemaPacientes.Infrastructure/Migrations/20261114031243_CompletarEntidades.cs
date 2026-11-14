using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPacientes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompletarEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recetas_Pacientes_PacienteId",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Tratamientos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Tratamientos");

            migrationBuilder.DropColumn(
                name: "Indicaciones",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "Alergias",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Diagnosticos");

            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "Consultorios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Consultorios");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Recetas",
                newName: "TratamientoId");

            migrationBuilder.RenameColumn(
                name: "FechaEmision",
                table: "Recetas",
                newName: "Fecha");

            migrationBuilder.RenameIndex(
                name: "IX_Recetas_PacienteId",
                table: "Recetas",
                newName: "IX_Recetas_TratamientoId");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Pacientes",
                newName: "Cedula");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Medicos",
                newName: "Exequatur");

            migrationBuilder.RenameColumn(
                name: "FechaDiagnostico",
                table: "Diagnosticos",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "Disponible",
                table: "Consultorios",
                newName: "Activo");

            migrationBuilder.AddColumn<int>(
                name: "DuracionDias",
                table: "Tratamientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "Recetas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Medicamentos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Recetas_Tratamientos_TratamientoId",
                table: "Recetas",
                column: "TratamientoId",
                principalTable: "Tratamientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recetas_Tratamientos_TratamientoId",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "DuracionDias",
                table: "Tratamientos");

            migrationBuilder.DropColumn(
                name: "Notas",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Medicamentos");

            migrationBuilder.RenameColumn(
                name: "TratamientoId",
                table: "Recetas",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Recetas",
                newName: "FechaEmision");

            migrationBuilder.RenameIndex(
                name: "IX_Recetas_TratamientoId",
                table: "Recetas",
                newName: "IX_Recetas_PacienteId");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "Pacientes",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "Exequatur",
                table: "Medicos",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Diagnosticos",
                newName: "FechaDiagnostico");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Consultorios",
                newName: "Disponible");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Tratamientos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Tratamientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Indicaciones",
                table: "Recetas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alergias",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Diagnosticos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "Consultorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Consultorios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Recetas_Pacientes_PacienteId",
                table: "Recetas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
