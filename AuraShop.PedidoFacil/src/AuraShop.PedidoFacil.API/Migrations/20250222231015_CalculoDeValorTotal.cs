using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuraShop.PedidoFacil.API.Migrations
{
    /// <inheritdoc />
    public partial class CalculoDeValorTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");
        }
    }
}
