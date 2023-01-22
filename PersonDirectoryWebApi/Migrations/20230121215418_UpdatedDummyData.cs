using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectoryWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "Path to her image");

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberTypeId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "Path to his image");

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberTypeId",
                value: 0);
        }
    }
}
