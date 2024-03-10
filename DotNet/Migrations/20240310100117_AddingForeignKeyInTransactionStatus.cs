using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsewaPractice.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeignKeyInTransactionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransactionStatus_ProductId",
                table: "TransactionStatus",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionStatus_ProductMerchantDetails_ProductId",
                table: "TransactionStatus",
                column: "ProductId",
                principalTable: "ProductMerchantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionStatus_ProductMerchantDetails_ProductId",
                table: "TransactionStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionStatus_ProductId",
                table: "TransactionStatus");
        }
    }
}
