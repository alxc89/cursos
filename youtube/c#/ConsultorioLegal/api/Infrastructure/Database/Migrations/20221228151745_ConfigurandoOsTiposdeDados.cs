using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioLegal.Migrations
{
    public partial class ConfigurandoOsTiposdeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "varchar",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<char>(
                name: "Sexo",
                table: "Clientes",
                type: "char",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(char),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "varchar",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Clientes",
                type: "varchar",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Id_Nome",
                table: "Clientes",
                columns: new[] { "Id", "Nome" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Id_Nome",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<char>(
                name: "Sexo",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "char",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Clientes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 14);
        }
    }
}
