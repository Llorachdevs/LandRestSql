using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandRest.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogUsers_AbpUsers_IdentityUserId",
                table: "BlogUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityUserId",
                table: "BlogUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogUsers_AbpUsers_IdentityUserId",
                table: "BlogUsers",
                column: "IdentityUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogUsers_AbpUsers_IdentityUserId",
                table: "BlogUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityUserId",
                table: "BlogUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogUsers_AbpUsers_IdentityUserId",
                table: "BlogUsers",
                column: "IdentityUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
