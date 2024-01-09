using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College.Migrations
{
    /// <inheritdoc />
    public partial class col1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__staff__staff_StaffId1",
                table: "_staff");

            migrationBuilder.DropIndex(
                name: "IX__staff_StaffId1",
                table: "_staff");

            migrationBuilder.DropColumn(
                name: "StaffId1",
                table: "_staff");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId1",
                table: "_staff",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX__staff_StaffId1",
                table: "_staff",
                column: "StaffId1");

            migrationBuilder.AddForeignKey(
                name: "FK__staff__staff_StaffId1",
                table: "_staff",
                column: "StaffId1",
                principalTable: "_staff",
                principalColumn: "StaffId");
        }
    }
}
