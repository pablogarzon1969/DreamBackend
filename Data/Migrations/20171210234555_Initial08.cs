using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class Initial08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Empresa_IdEmpresa",
                table: "Hotel");

            migrationBuilder.CreateTable(
                name: "HabitacionesDisponibles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdHotel = table.Column<int>(type: "int", nullable: true),
                    TotalHabitacionesDisponibles = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionesDisponibles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitacionesDisponibles_Hotel_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionesDisponibles_IdHotel",
                table: "HabitacionesDisponibles",
                column: "IdHotel");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Empresa_IdEmpresa",
                table: "Hotel",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Empresa_IdEmpresa",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "HabitacionesDisponibles");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Empresa_IdEmpresa",
                table: "Hotel",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
