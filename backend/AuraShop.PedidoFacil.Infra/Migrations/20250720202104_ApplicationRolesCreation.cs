using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuraShop.PedidoFacil.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationRolesCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetRoles");
        }
    }
}
