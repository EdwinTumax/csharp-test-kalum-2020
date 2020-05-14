using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CompleteModelKalum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarreraTecnicas",
                columns: table => new
                {
                    CarreraTecnicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraTecnicas", x => x.CarreraTecnicaId);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioInicio = table.Column<DateTime>(nullable: false),
                    HorarioFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Instructores",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    SalonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSalon = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Capacidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.SalonId);
                });

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    ClaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Ciclo = table.Column<int>(nullable: false),
                    CarreraTecnicaId = table.Column<int>(nullable: false),
                    SalonId = table.Column<int>(nullable: false),
                    HorarioId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    CupoMinimo = table.Column<int>(nullable: false),
                    CupoMaximo = table.Column<int>(nullable: false),
                    CantidadAsignaciones = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.ClaseId);
                    table.ForeignKey(
                        name: "FK_Clase_CarreraTecnicas_CarreraTecnicaId",
                        column: x => x.CarreraTecnicaId,
                        principalTable: "CarreraTecnicas",
                        principalColumn: "CarreraTecnicaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clase_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clase_Instructores_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructores",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clase_Salones_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salones",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionAlumno",
                columns: table => new
                {
                    AsignacionAlumnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaseId = table.Column<int>(nullable: false),
                    AlumnoId = table.Column<int>(nullable: false),
                    FechaAsignacion = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionAlumno", x => x.AsignacionAlumnoId);
                    table.ForeignKey(
                        name: "FK_AsignacionAlumno_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionAlumno_Clase_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clase",
                        principalColumn: "ClaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionAlumno_AlumnoId",
                table: "AsignacionAlumno",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionAlumno_ClaseId",
                table: "AsignacionAlumno",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clase",
                column: "CarreraTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_HorarioId",
                table: "Clase",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_InstructorId",
                table: "Clase",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_SalonId",
                table: "Clase",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionAlumno");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropTable(
                name: "CarreraTecnicas");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Instructores");

            migrationBuilder.DropTable(
                name: "Salones");
        }
    }
}
