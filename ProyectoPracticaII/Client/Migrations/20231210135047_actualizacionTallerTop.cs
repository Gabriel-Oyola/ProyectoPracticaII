using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPracticaII.Client.Migrations
{
    /// <inheritdoc />
    public partial class actualizacionTallerTop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_IdTaller",
                table: "TallerTop");

            migrationBuilder.DropColumn(
                name: "LinkTaller",
                table: "TallerTop");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TallerTop");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "TallerTop");

            migrationBuilder.AlterColumn<int>(
                name: "IdTaller",
                table: "TallerTop",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreTaller",
                table: "TallerTop",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PromedioRating",
                table: "TallerTop",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Motocicletas",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_IdTaller",
                table: "TallerTop",
                column: "IdTaller",
                principalTable: "Taller",
                principalColumn: "IdTaller",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_IdTaller",
                table: "TallerTop");

            migrationBuilder.DropColumn(
                name: "NombreTaller",
                table: "TallerTop");

            migrationBuilder.DropColumn(
                name: "PromedioRating",
                table: "TallerTop");

            migrationBuilder.AlterColumn<int>(
                name: "IdTaller",
                table: "TallerTop",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "LinkTaller",
                table: "TallerTop",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TallerTop",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "TallerTop",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Motocicletas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_IdTaller",
                table: "TallerTop",
                column: "IdTaller",
                principalTable: "Taller",
                principalColumn: "IdTaller");
        }
    }
}
