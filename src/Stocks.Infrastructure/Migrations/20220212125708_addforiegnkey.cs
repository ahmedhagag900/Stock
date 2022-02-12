using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Infrastructure.Migrations
{
    public partial class addforiegnkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrice_Stocks_StockId",
                table: "StockPrice");

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrice_Stocks_StockId",
                table: "StockPrice",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrice_Stocks_StockId",
                table: "StockPrice");

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrice_Stocks_StockId",
                table: "StockPrice",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
