using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dopadCore.Data.Migrations
{
    public partial class Works : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AlternateContact = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Expiry = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    ImgUrl2 = table.Column<string>(nullable: true),
                    ImgUrl3 = table.Column<string>(nullable: true),
                    ImgUrl4 = table.Column<string>(nullable: true),
                    ImgUrl5 = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: true),
                    PostingDate = table.Column<DateTime>(nullable: true),
                    PostingUserID = table.Column<string>(nullable: true),
                    RenumerationAmount = table.Column<string>(nullable: true),
                    RenumerationType = table.Column<string>(nullable: true),
                    SkillLevel = table.Column<int>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    WorkCategory = table.Column<string>(nullable: true),
                    WorkType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_AspNetUserId",
                table: "Work",
                column: "AspNetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
