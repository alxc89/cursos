using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioLegal.Migrations
{
    public partial class addDtCriacaoEDtAlteracaoMedicoEEspecialidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Medicos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAlteracao",
                table: "Medicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Especialidades",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAlteracao",
                table: "Especialidades",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "UltimaAlteracao",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "UltimaAlteracao",
                table: "Especialidades");
        }
    }
}
