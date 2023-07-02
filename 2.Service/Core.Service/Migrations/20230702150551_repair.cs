using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class repair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "T_Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "T_Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Users_Email",
                table: "T_Users",
                column: "Email",
                unique: true);

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
            migrationBuilder.DropTable(
                name: "T_Role");

            migrationBuilder.DropIndex(
                name: "IX_T_Users_Email",
                table: "T_Users");

            migrationBuilder.DropIndex(
                name: "IX_T_Users_Name",
                table: "T_Users");

            migrationBuilder.DropIndex(
                name: "IX_T_Users_PhoneNumber",
                table: "T_Users");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "T_Users");
        }
    }
}
