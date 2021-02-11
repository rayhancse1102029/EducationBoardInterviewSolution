using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSideBar.Migrations
{
    public partial class v_user_access_page_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccessPages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<bool>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    roleId = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: true),
                    parentId = table.Column<int>(nullable: true),
                    bandId = table.Column<int>(nullable: true),
                    navItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccessPages_NavBands_bandId",
                        column: x => x.bandId,
                        principalTable: "NavBands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccessPages_NavModules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "NavModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccessPages_NavItems_navItemId",
                        column: x => x.navItemId,
                        principalTable: "NavItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccessPages_NavParents_parentId",
                        column: x => x.parentId,
                        principalTable: "NavParents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccessPages_AspNetRoles_roleId",
                        column: x => x.roleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessPages_bandId",
                table: "UserAccessPages",
                column: "bandId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessPages_moduleId",
                table: "UserAccessPages",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessPages_navItemId",
                table: "UserAccessPages",
                column: "navItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessPages_parentId",
                table: "UserAccessPages",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessPages_roleId",
                table: "UserAccessPages",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccessPages");
        }
    }
}
