using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI_Main.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Students",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "email");
        }
    }
}
