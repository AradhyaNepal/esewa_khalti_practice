using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsewaPractice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductMerchantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountRs = table.Column<int>(type: "int", nullable: false),
                    EsewaClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsewaClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsewaSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhaltiPublicKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhaltiPrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMerchantDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMerchantDetails");
        }
    }
}
