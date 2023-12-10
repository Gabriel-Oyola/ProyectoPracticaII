using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPracticaII.Client.Migrations
{
    /// <inheritdoc />
    public partial class pkTallerTop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTop",
                table: "TallerTop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTop",
                table: "TallerTop");
        }
    }
}
