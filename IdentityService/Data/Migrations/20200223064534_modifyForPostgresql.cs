using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IdentityService.Data.Migrations
{
    public partial class modifyForPostgresql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.EnsureSchema(
                name: "id");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "identityusertoken<string>",
                newSchema: "id");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "applicationuser",
                newSchema: "id");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "identityuserrole<string>",
                newSchema: "id");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "identityuserlogin<string>",
                newSchema: "id");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "identityuserclaim<string>",
                newSchema: "id");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "identityrole",
                newSchema: "id");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "identityroleclaim<string>",
                newSchema: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "id",
                table: "identityuserrole<string>",
                newName: "IX_identityuserrole<string>_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "id",
                table: "identityuserlogin<string>",
                newName: "IX_identityuserlogin<string>_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "id",
                table: "identityuserclaim<string>",
                newName: "IX_identityuserclaim<string>_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "id",
                table: "identityroleclaim<string>",
                newName: "IX_identityroleclaim<string>_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "id",
                table: "identityuserclaim<string>",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "id",
                table: "identityroleclaim<string>",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_identityusertoken<string>",
                schema: "id",
                table: "identityusertoken<string>",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicationuser",
                schema: "id",
                table: "applicationuser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_identityuserrole<string>",
                schema: "id",
                table: "identityuserrole<string>",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_identityuserlogin<string>",
                schema: "id",
                table: "identityuserlogin<string>",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_identityuserclaim<string>",
                schema: "id",
                table: "identityuserclaim<string>",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_identityrole",
                schema: "id",
                table: "identityrole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_identityroleclaim<string>",
                schema: "id",
                table: "identityroleclaim<string>",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_identityroleclaim<string>_identityrole_RoleId",
                schema: "id",
                table: "identityroleclaim<string>",
                column: "RoleId",
                principalSchema: "id",
                principalTable: "identityrole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_identityuserclaim<string>_applicationuser_UserId",
                schema: "id",
                table: "identityuserclaim<string>",
                column: "UserId",
                principalSchema: "id",
                principalTable: "applicationuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_identityuserlogin<string>_applicationuser_UserId",
                schema: "id",
                table: "identityuserlogin<string>",
                column: "UserId",
                principalSchema: "id",
                principalTable: "applicationuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_identityuserrole<string>_identityrole_RoleId",
                schema: "id",
                table: "identityuserrole<string>",
                column: "RoleId",
                principalSchema: "id",
                principalTable: "identityrole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_identityuserrole<string>_applicationuser_UserId",
                schema: "id",
                table: "identityuserrole<string>",
                column: "UserId",
                principalSchema: "id",
                principalTable: "applicationuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_identityusertoken<string>_applicationuser_UserId",
                schema: "id",
                table: "identityusertoken<string>",
                column: "UserId",
                principalSchema: "id",
                principalTable: "applicationuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_identityroleclaim<string>_identityrole_RoleId",
                schema: "id",
                table: "identityroleclaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_identityuserclaim<string>_applicationuser_UserId",
                schema: "id",
                table: "identityuserclaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_identityuserlogin<string>_applicationuser_UserId",
                schema: "id",
                table: "identityuserlogin<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_identityuserrole<string>_identityrole_RoleId",
                schema: "id",
                table: "identityuserrole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_identityuserrole<string>_applicationuser_UserId",
                schema: "id",
                table: "identityuserrole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_identityusertoken<string>_applicationuser_UserId",
                schema: "id",
                table: "identityusertoken<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identityusertoken<string>",
                schema: "id",
                table: "identityusertoken<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identityuserrole<string>",
                schema: "id",
                table: "identityuserrole<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identityuserlogin<string>",
                schema: "id",
                table: "identityuserlogin<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identityuserclaim<string>",
                schema: "id",
                table: "identityuserclaim<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identityroleclaim<string>",
                schema: "id",
                table: "identityroleclaim<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identityrole",
                schema: "id",
                table: "identityrole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applicationuser",
                schema: "id",
                table: "applicationuser");

            migrationBuilder.RenameTable(
                name: "identityusertoken<string>",
                schema: "id",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "identityuserrole<string>",
                schema: "id",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "identityuserlogin<string>",
                schema: "id",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "identityuserclaim<string>",
                schema: "id",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "identityroleclaim<string>",
                schema: "id",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "identityrole",
                schema: "id",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "applicationuser",
                schema: "id",
                newName: "AspNetUsers");

            migrationBuilder.RenameIndex(
                name: "IX_identityuserrole<string>_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_identityuserlogin<string>_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_identityuserclaim<string>_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_identityroleclaim<string>_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
