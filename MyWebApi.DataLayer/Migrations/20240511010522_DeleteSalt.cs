using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "password_salt",
                table: "users",
                newName: "password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "password_salt");

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
