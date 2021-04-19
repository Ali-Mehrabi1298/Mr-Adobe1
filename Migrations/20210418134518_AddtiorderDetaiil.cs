using Microsoft.EntityFrameworkCore.Migrations;

namespace MohamadShop.Migrations
{
    public partial class AddtiorderDetaiil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_Order_OrderId",
                table: "orderdetails");

            migrationBuilder.DropColumn(
                name: "orderIdd",
                table: "orderdetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "orderdetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_Order_OrderId",
                table: "orderdetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_Order_OrderId",
                table: "orderdetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "orderdetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "orderIdd",
                table: "orderdetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_Order_OrderId",
                table: "orderdetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
