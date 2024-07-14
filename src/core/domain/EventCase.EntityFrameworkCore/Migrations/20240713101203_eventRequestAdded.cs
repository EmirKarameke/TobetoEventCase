using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventCase.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class eventRequestAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    RequestStatu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRequest_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventRequest_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_EventId",
                table: "EventRequest",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_MemberId",
                table: "EventRequest",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRequest");
        }
    }
}
