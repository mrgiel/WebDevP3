using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class idkfam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Klant_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Klant_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Klant_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Klant_UserId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Klant",
                table: "Klant");

            migrationBuilder.RenameTable(
                name: "Klant",
                newName: "Gebruiker");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Gebruiker",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<int>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApplicationUserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<int>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<int>_Gebruiker_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim<int>_ApplicationUserId",
                table: "IdentityUserClaim<int>",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Gebruiker_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Gebruiker_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Gebruiker_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Gebruiker_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Gebruiker_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Gebruiker_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Gebruiker_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Gebruiker_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<int>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Gebruiker");

            migrationBuilder.RenameTable(
                name: "Gebruiker",
                newName: "Klant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klant",
                table: "Klant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Klant_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Klant_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Klant_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Klant_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
