using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI_Main.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDTO20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classses_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rankings_RankingId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RankingId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RankingId",
                table: "Students",
                column: "RankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classses_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rankings_RankingId",
                table: "Students",
                column: "RankingId",
                principalTable: "Rankings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
