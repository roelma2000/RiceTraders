using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiceTrader.Migrations
{
    public partial class UpdateFinalOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "FinalOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "FinalOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "FinalOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "FinalOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductSize",
                table: "FinalOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FinalOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "FinalOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "FinalOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "ProductSize",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "FinalOrders");
        }
    }
}
