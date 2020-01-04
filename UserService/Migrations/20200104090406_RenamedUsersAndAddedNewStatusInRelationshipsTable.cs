using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class RenamedUsersAndAddedNewStatusInRelationshipsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user1",
                table: "relationships");

            migrationBuilder.DropColumn(
                name: "user2",
                table: "relationships");

            migrationBuilder.AddColumn<Guid>(
                name: "requestee",
                table: "relationships",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "requestor",
                table: "relationships",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "relationships",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "relationships",
                keyColumn: "id",
                keyValue: new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                columns: new[] { "requestee", "requestor", "status" },
                values: new object[] { new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), "accepted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requestee",
                table: "relationships");

            migrationBuilder.DropColumn(
                name: "requestor",
                table: "relationships");

            migrationBuilder.DropColumn(
                name: "status",
                table: "relationships");

            migrationBuilder.AddColumn<Guid>(
                name: "user1",
                table: "relationships",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "user2",
                table: "relationships",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "relationships",
                keyColumn: "id",
                keyValue: new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                columns: new[] { "user1", "user2" },
                values: new object[] { new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6") });
        }
    }
}
