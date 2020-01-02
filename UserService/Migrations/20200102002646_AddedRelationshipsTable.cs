using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class AddedRelationshipsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "relationships",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    user1 = table.Column<Guid>(nullable: false),
                    user2 = table.Column<Guid>(nullable: false),
                    relationship_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relationships", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "relationships",
                columns: new[] { "id", "relationship_type", "user1", "user2" },
                values: new object[] { new Guid("709fb6ba-705a-449b-8060-d09626deca01"), "friend", new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relationships");
        }
    }
}
