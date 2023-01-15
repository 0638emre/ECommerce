using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistance.Migrations
{
    public partial class _230615012023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleEndpoint_Endpoint_EndpointsId",
                table: "AppRoleEndpoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Endpoint_Menu_MenuId",
                table: "Endpoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endpoint",
                table: "Endpoint");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Endpoint",
                newName: "Endpoints");

            migrationBuilder.RenameIndex(
                name: "IX_Endpoint_MenuId",
                table: "Endpoints",
                newName: "IX_Endpoints_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endpoints",
                table: "Endpoints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleEndpoint_Endpoints_EndpointsId",
                table: "AppRoleEndpoint",
                column: "EndpointsId",
                principalTable: "Endpoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleEndpoint_Endpoints_EndpointsId",
                table: "AppRoleEndpoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endpoints",
                table: "Endpoints");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "Endpoints",
                newName: "Endpoint");

            migrationBuilder.RenameIndex(
                name: "IX_Endpoints_MenuId",
                table: "Endpoint",
                newName: "IX_Endpoint_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endpoint",
                table: "Endpoint",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleEndpoint_Endpoint_EndpointsId",
                table: "AppRoleEndpoint",
                column: "EndpointsId",
                principalTable: "Endpoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoint_Menu_MenuId",
                table: "Endpoint",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
