using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaçãoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInsercao",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "UsuarioInsercao",
                table: "Telefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataInsercao",
                table: "Telefone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInsercao",
                table: "Telefone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
