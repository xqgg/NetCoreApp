using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class editUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_Users_Name",
                table: "T_Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Users_PhoneNumber",
                table: "T_Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_Users_Name",
                table: "T_Users");

            migrationBuilder.DropIndex(
                name: "IX_T_Users_PhoneNumber",
                table: "T_Users");
        }
    }
}
