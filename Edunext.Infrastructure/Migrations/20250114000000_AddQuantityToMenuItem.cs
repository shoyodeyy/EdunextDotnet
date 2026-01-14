using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edunext.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thêm cột Quantity
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Xóa cột IsAvailable vì nó là computed property
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "MenuItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rollback: Thêm lại cột IsAvailable
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            // Rollback: Xóa cột Quantity
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MenuItems");
        }
    }
}


