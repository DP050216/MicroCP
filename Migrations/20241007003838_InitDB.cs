using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServicioCP.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasena = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("PK_Cliente", x => x.ClienteID);
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
