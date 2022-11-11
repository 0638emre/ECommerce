using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistance.Migrations
{
    public partial class _21239112022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "productId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_productId",
                table: "Files",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_productId",
                table: "Files",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_productId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_productId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Files");
        }
    }
}
