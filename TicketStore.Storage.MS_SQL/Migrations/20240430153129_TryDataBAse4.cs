using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class TryDataBAse4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "OrdersIsnNode",
                table: "Concerts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrdersIsnNode",
                table: "Concerts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_OrdersIsnNode",
                table: "Concerts",
                column: "OrdersIsnNode");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts",
                column: "OrdersIsnNode",
                principalTable: "Order",
                principalColumn: "IsnNode");
        }
    }
}
