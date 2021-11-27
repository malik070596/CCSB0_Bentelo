using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB_Bentelo.Migrations
{
    public partial class Vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Airco",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Beds",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Bicycle",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Km",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Tow",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Water",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airco",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Beds",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Bicycle",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Km",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Tow",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicle");
        }
    }
}
