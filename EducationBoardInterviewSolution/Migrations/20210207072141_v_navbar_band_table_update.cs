using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationBoardInterviewSolution.Migrations
{
    public partial class v_navbar_band_table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NabBands_NavParents_navParentId",
                table: "NabBands");

            migrationBuilder.DropForeignKey(
                name: "FK_NavItems_NabBands_navBandId",
                table: "NavItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NabBands",
                table: "NabBands");

            migrationBuilder.RenameTable(
                name: "NabBands",
                newName: "NavBands");

            migrationBuilder.RenameIndex(
                name: "IX_NabBands_navParentId",
                table: "NavBands",
                newName: "IX_NavBands_navParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NavBands",
                table: "NavBands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NavBands_NavParents_navParentId",
                table: "NavBands",
                column: "navParentId",
                principalTable: "NavParents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NavItems_NavBands_navBandId",
                table: "NavItems",
                column: "navBandId",
                principalTable: "NavBands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NavBands_NavParents_navParentId",
                table: "NavBands");

            migrationBuilder.DropForeignKey(
                name: "FK_NavItems_NavBands_navBandId",
                table: "NavItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NavBands",
                table: "NavBands");

            migrationBuilder.RenameTable(
                name: "NavBands",
                newName: "NabBands");

            migrationBuilder.RenameIndex(
                name: "IX_NavBands_navParentId",
                table: "NabBands",
                newName: "IX_NabBands_navParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NabBands",
                table: "NabBands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NabBands_NavParents_navParentId",
                table: "NabBands",
                column: "navParentId",
                principalTable: "NavParents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NavItems_NabBands_navBandId",
                table: "NavItems",
                column: "navBandId",
                principalTable: "NabBands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
