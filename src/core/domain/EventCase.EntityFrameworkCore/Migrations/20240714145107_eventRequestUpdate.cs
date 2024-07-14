using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventCase.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class eventRequestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Members_MemberId",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_EventRequest_MemberId",
                table: "EventRequest");

            migrationBuilder.AddColumn<Guid>(
                name: "EventRequestId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "EventRequest",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Members_EventRequestId",
                table: "Members",
                column: "EventRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_EventRequest_EventRequestId",
                table: "Members",
                column: "EventRequestId",
                principalTable: "EventRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_EventRequest_EventRequestId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_EventRequestId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "EventRequestId",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "EventRequest",
                type: "UniqueIdentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_MemberId",
                table: "EventRequest",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequest_Members_MemberId",
                table: "EventRequest",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
