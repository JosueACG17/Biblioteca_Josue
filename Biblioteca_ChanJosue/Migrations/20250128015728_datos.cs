using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_ChanJosue.Migrations
{
    /// <inheritdoc />
    public partial class datos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[] { 2, "Editor" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[] { 3, "Lector" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUsuario", "FkRol", "Nombre", "Password", "Username" },
                values: new object[] { 1, 1, "JosueChan", "Josue123", "Hipprx" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUsuario", "FkRol", "Nombre", "Password", "Username" },
                values: new object[] { 2, 2, "AnaLopez", "Ana123", "AnaEditor" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUsuario", "FkRol", "Nombre", "Password", "Username" },
                values: new object[] { 3, 3, "CarlosRuiz", "Carlos123", "CarlosLector" });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "PkUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PkRol",
                keyValue: 1);
        }
    }
}
