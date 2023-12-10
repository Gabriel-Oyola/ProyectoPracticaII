using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPracticaII.Client.Migrations
{
    /// <inheritdoc />
    public partial class ATLT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdTop",
                table: "TallerTop",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TallerTo__2BC545E13E345D15",
                table: "TallerTop",
                column: "IdTop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__TallerTo__2BC545E13E345D15",
                table: "TallerTop");

            migrationBuilder.AlterColumn<int>(
                name: "IdTop",
                table: "TallerTop",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
