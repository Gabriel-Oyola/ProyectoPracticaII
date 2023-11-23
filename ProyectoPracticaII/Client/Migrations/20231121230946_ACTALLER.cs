using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPracticaII.Client.Migrations
{
    /// <inheritdoc />
    public partial class ACTALLER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Clave = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF97E5CC0B2D", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Motocicletas",
                columns: table => new
                {
                    idMoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Patente = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Marca = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Modelo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Año = table.Column<int>(type: "int", nullable: true),
                    Aseguradora = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Motocicl__C0D1CACF584CC891", x => x.idMoto);
                    table.ForeignKey(
                        name: "fk_moto",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Taller",
                columns: table => new
                {
                    IdTaller = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    NombreTaller = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    País = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Provincia = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Localidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Horarios = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LinksMapa = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Taller__AC44FFD633AC2651", x => x.IdTaller);
                    table.ForeignKey(
                        name: "fk_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "opiniones",
                columns: table => new
                {
                    IdOpinion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdTaller = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fecha = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__opinione__2F8F71D7CB0B9203", x => x.IdOpinion);
                    table.ForeignKey(
                        name: "fk_IdTallerr",
                        column: x => x.IdTaller,
                        principalTable: "Taller",
                        principalColumn: "IdTaller");
                    table.ForeignKey(
                        name: "fk_IdUsuarioO",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "TallerTop",
                columns: table => new
                {
                    IdTaller = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LinkTaller = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_IdTaller",
                        column: x => x.IdTaller,
                        principalTable: "Taller",
                        principalColumn: "IdTaller");
                });

            migrationBuilder.CreateTable(
                name: "ReportesOpiniones",
                columns: table => new
                {
                    IdReporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioRC = table.Column<int>(type: "int", nullable: true),
                    IdTaller = table.Column<int>(type: "int", nullable: true),
                    IdOpinion = table.Column<int>(type: "int", nullable: true),
                    comentario = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fecha = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Motivo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reportes__F9561136C9B2406A", x => x.IdReporte);
                    table.ForeignKey(
                        name: "fk_IdOpinion",
                        column: x => x.IdOpinion,
                        principalTable: "opiniones",
                        principalColumn: "IdOpinion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motocicletas_IdUsuario",
                table: "Motocicletas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_opiniones_IdTaller",
                table: "opiniones",
                column: "IdTaller");

            migrationBuilder.CreateIndex(
                name: "IX_opiniones_IdUsuario",
                table: "opiniones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesOpiniones_IdOpinion",
                table: "ReportesOpiniones",
                column: "IdOpinion");

            migrationBuilder.CreateIndex(
                name: "IX_Taller_IdUsuario",
                table: "Taller",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TallerTop_IdTaller",
                table: "TallerTop",
                column: "IdTaller");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motocicletas");

            migrationBuilder.DropTable(
                name: "ReportesOpiniones");

            migrationBuilder.DropTable(
                name: "TallerTop");

            migrationBuilder.DropTable(
                name: "opiniones");

            migrationBuilder.DropTable(
                name: "Taller");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
