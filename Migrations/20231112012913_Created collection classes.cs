using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI_Main.Migrations
{
    /// <inheritdoc />
    public partial class Createdcollectionclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Classses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classses",
                keyColumn: "Id",
                keyValue: new Guid("0d06acb7-5ad4-458c-b26e-a3b390994335"),
                column: "StudentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classses",
                keyColumn: "Id",
                keyValue: new Guid("237b0357-dfb0-49e9-90a9-0a25933c439e"),
                column: "StudentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classses",
                keyColumn: "Id",
                keyValue: new Guid("5c47bab3-293b-4b64-8860-bdeb1516ed43"),
                column: "StudentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classses",
                keyColumn: "Id",
                keyValue: new Guid("69e61e7e-6b80-4cde-b016-3a253e9a0c45"),
                column: "StudentId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RankingId",
                table: "Students",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_Classses_StudentId",
                table: "Classses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classses_Students_StudentId",
                table: "Classses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classses_Students_StudentId",
                table: "Classses");

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

            migrationBuilder.DropIndex(
                name: "IX_Classses_StudentId",
                table: "Classses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Classses");
        }
    }
}
