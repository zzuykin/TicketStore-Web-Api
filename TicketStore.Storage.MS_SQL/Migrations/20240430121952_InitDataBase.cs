using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClientSurname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CLientEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrderNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNum = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Order_Users_IsnUser",
                        column: x => x.IsnUser,
                        principalTable: "Users",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnOrders = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    ConcertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    TicketPrice = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Concerts_Order_IsnOrders",
                        column: x => x.IsnOrders,
                        principalTable: "Order",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_IsnOrders",
                table: "Concerts",
                column: "IsnOrders");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IsnUser",
                table: "Order",
                column: "IsnUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrderNum",
                table: "Users",
                column: "OrderNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
