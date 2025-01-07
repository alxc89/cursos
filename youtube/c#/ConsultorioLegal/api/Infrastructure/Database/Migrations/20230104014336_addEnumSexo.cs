using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioLegal.Migrations
{
    public partial class addEnumSexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "char",
                oldMaxLength: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Sexo",
                table: "Clientes",
                type: "char",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
