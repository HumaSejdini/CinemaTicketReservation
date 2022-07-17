using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.Repository.Migrations
{
    public partial class addedQuantityToMovieInReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MovieInReservations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MovieInReservations");
        }
    }
}
