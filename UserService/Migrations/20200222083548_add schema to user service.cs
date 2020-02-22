using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class addschematouserservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user_service");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "user_service");

            migrationBuilder.RenameTable(
                name: "relationships",
                newName: "relationships",
                newSchema: "user_service");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "user_service",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "relationships",
                schema: "user_service",
                newName: "relationships");
        }
    }
}
