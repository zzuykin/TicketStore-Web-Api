using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Order_IsnOrders",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_IsnOrders",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "IsnOrders",
                table: "Concerts");

            migrationBuilder.AlterColumn<string>(
                name: "ConcertName",
                table: "Concerts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdersIsnNode",
                table: "Concerts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ConcertName",
                table: "Concerts",
                column: "ConcertName");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Order_OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_ConcertName",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "OrdersIsnNode",
                table: "Concerts");

            migrationBuilder.AlterColumn<string>(
                name: "ConcertName",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<Guid>(
                name: "IsnOrders",
                table: "Concerts",
                type: "uniqueidentifier",
                maxLength: 255,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_IsnOrders",
                table: "Concerts",
                column: "IsnOrders");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Order_IsnOrders",
                table: "Concerts",
                column: "IsnOrders",
                principalTable: "Order",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
