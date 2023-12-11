using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPracticaII.Client.Migrations
{
    /// <inheritdoc />
    public partial class upUsuarioNl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DNI",
                table: "Usuario",
                type: "real",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Usuario",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Usuario",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
