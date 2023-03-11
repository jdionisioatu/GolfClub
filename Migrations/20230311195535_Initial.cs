using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfClub.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MembershipNumberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Handicap = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MembershipNumberId);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerOneId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerTwoId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerThreeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerFourId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeeTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Member_PlayerFourId",
                        column: x => x.PlayerFourId,
                        principalTable: "Member",
                        principalColumn: "MembershipNumberId");
                    table.ForeignKey(
                        name: "FK_Booking_Member_PlayerOneId",
                        column: x => x.PlayerOneId,
                        principalTable: "Member",
                        principalColumn: "MembershipNumberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Member_PlayerThreeId",
                        column: x => x.PlayerThreeId,
                        principalTable: "Member",
                        principalColumn: "MembershipNumberId");
                    table.ForeignKey(
                        name: "FK_Booking_Member_PlayerTwoId",
                        column: x => x.PlayerTwoId,
                        principalTable: "Member",
                        principalColumn: "MembershipNumberId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PlayerFourId",
                table: "Booking",
                column: "PlayerFourId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PlayerOneId",
                table: "Booking",
                column: "PlayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PlayerThreeId",
                table: "Booking",
                column: "PlayerThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PlayerTwoId",
                table: "Booking",
                column: "PlayerTwoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
