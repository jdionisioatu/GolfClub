using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfClub.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIDs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerFourId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerOneId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerThreeId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerTwoId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoId",
                table: "Booking",
                newName: "PlayerTwoMembershipNumberId");

            migrationBuilder.RenameColumn(
                name: "PlayerThreeId",
                table: "Booking",
                newName: "PlayerThreeMembershipNumberId");

            migrationBuilder.RenameColumn(
                name: "PlayerOneId",
                table: "Booking",
                newName: "PlayerOneMembershipNumberId");

            migrationBuilder.RenameColumn(
                name: "PlayerFourId",
                table: "Booking",
                newName: "PlayerFourMembershipNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerTwoId",
                table: "Booking",
                newName: "IX_Booking_PlayerTwoMembershipNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerThreeId",
                table: "Booking",
                newName: "IX_Booking_PlayerThreeMembershipNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerOneId",
                table: "Booking",
                newName: "IX_Booking_PlayerOneMembershipNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerFourId",
                table: "Booking",
                newName: "IX_Booking_PlayerFourMembershipNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerFourMembershipNumberId",
                table: "Booking",
                column: "PlayerFourMembershipNumberId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerOneMembershipNumberId",
                table: "Booking",
                column: "PlayerOneMembershipNumberId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerThreeMembershipNumberId",
                table: "Booking",
                column: "PlayerThreeMembershipNumberId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerTwoMembershipNumberId",
                table: "Booking",
                column: "PlayerTwoMembershipNumberId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerFourMembershipNumberId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerOneMembershipNumberId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerThreeMembershipNumberId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Member_PlayerTwoMembershipNumberId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoMembershipNumberId",
                table: "Booking",
                newName: "PlayerTwoId");

            migrationBuilder.RenameColumn(
                name: "PlayerThreeMembershipNumberId",
                table: "Booking",
                newName: "PlayerThreeId");

            migrationBuilder.RenameColumn(
                name: "PlayerOneMembershipNumberId",
                table: "Booking",
                newName: "PlayerOneId");

            migrationBuilder.RenameColumn(
                name: "PlayerFourMembershipNumberId",
                table: "Booking",
                newName: "PlayerFourId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerTwoMembershipNumberId",
                table: "Booking",
                newName: "IX_Booking_PlayerTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerThreeMembershipNumberId",
                table: "Booking",
                newName: "IX_Booking_PlayerThreeId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerOneMembershipNumberId",
                table: "Booking",
                newName: "IX_Booking_PlayerOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PlayerFourMembershipNumberId",
                table: "Booking",
                newName: "IX_Booking_PlayerFourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerFourId",
                table: "Booking",
                column: "PlayerFourId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerOneId",
                table: "Booking",
                column: "PlayerOneId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerThreeId",
                table: "Booking",
                column: "PlayerThreeId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Member_PlayerTwoId",
                table: "Booking",
                column: "PlayerTwoId",
                principalTable: "Member",
                principalColumn: "MembershipNumberId");
        }
    }
}
