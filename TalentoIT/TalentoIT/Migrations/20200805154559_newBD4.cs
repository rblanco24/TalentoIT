using Microsoft.EntityFrameworkCore.Migrations;

namespace TalentoIT.Migrations
{
    public partial class newBD4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoTecnlogia",
                table: "TecnologiaEntity",
                newName: "TipoTecnologia");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TecnologiaEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TecnologiaEntity");

            migrationBuilder.RenameColumn(
                name: "TipoTecnologia",
                table: "TecnologiaEntity",
                newName: "TipoTecnlogia");
        }
    }
}
