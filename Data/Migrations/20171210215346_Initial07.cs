using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class Initial07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_IdEmpresa",
                table: "Hotel",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Empresa_IdEmpresa",
                table: "Hotel",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Empresa_IdEmpresa",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_IdEmpresa",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Hotel");
        }
    }
}
