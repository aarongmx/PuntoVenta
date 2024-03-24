using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorePuntoVenta.Migrations
{
    /// <inheritdoc />
    public partial class seAgregaColumnaAlgoACliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "algo",
                table: "cuentas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "algo",
                table: "cuentas");
        }
    }
}
