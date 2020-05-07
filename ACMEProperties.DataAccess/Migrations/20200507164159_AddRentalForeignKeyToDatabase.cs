using Microsoft.EntityFrameworkCore.Migrations;

namespace ACMEProperties.DataAccess.Migrations
{
    public partial class AddRentalForeignKeyToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Property_RentalId",
                table: "Property",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Rental_RentalId",
                table: "Property",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Rental_RentalId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_RentalId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "Property");
        }
    }
}
