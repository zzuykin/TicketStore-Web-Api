using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class NewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_OrderNum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderNum",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Code",
                table: "Users",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Code",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "OrderNum",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrderNum",
                table: "Users",
                column: "OrderNum");
        }
    }
}
