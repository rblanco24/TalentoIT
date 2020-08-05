using Microsoft.EntityFrameworkCore.Migrations;

namespace TalentoIT.Migrations
{
    public partial class newBD1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Candidato",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "website",
                table: "Candidato",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "website",
                table: "Candidato");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Candidato",
                newName: "Id");
        }
    }
}
