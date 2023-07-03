using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SugerenciasMacEV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    NombreModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autonomia = table.Column<int>(type: "int", nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoSoportado = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloId);
                });

            migrationBuilder.CreateTable(
                name: "Informes",
                columns: table => new
                {
                    InformeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informes", x => x.InformeId);
                    table.ForeignKey(
                        name: "FK_Informes_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informes_ModeloId",
                table: "Informes",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
