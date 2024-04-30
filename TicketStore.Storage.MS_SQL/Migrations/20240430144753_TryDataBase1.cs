using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class TryDataBase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrdersIsnNode",
                table: "Concerts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts",
                column: "OrdersIsnNode",
                principalTable: "Order",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrdersIsnNode",
                table: "Concerts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts",
                column: "OrdersIsnNode",
                principalTable: "Order",
                principalColumn: "IsnNode");
        }
    }
}
