using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRentals.Migrations
{
    /// <inheritdoc />
    public partial class addedcommentproptoVehiclemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Vehicles");
        }
    }
}
