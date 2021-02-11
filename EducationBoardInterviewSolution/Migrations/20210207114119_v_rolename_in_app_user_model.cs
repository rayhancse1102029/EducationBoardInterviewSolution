using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSideBar.Migrations
{
    public partial class v_rolename_in_app_user_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleName",
                table: "AspNetUsers");
        }
    }
}
