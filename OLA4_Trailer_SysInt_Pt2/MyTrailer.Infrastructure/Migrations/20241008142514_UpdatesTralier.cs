using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTrailer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesTralier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBooked",
                table: "Trailers",
                newName: "IsRented");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Rentals",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "IsRented",
                table: "Trailers",
                newName: "IsBooked");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Rentals",
                newName: "Amount");
        }
    }
}
