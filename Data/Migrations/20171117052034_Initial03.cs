using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class Initial03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservaHabitacionCierreVoucher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReservaHabitacionCierre = table.Column<int>(type: "int", nullable: false),
                    NumeroVoucher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHabitacionCierreVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacionCierreVoucher_ReservaHabitacionCierre_IdReservaHabitacionCierre",
                        column: x => x.IdReservaHabitacionCierre,
                        principalTable: "ReservaHabitacionCierre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacionCierreVoucher_IdReservaHabitacionCierre",
                table: "ReservaHabitacionCierreVoucher",
                column: "IdReservaHabitacionCierre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaHabitacionCierreVoucher");
        }
    }
}
