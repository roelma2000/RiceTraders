using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiceTrader.Migrations
{
    public partial class LinkFinalOrderToPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PurchaseOrder");

            migrationBuilder.CreateTable(
                name: "FinalOrders",
                columns: table => new
                {
                    FinalOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrders", x => x.FinalOrderId);
                    table.ForeignKey(
                        name: "FK_FinalOrders_PurchaseOrder_PoId",
                        column: x => x.PoId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrders_PoId",
                table: "FinalOrders",
                column: "PoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "PurchaseOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
