using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonDirectoryWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Batumi" },
                    { 3, "Zugdidi" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "GenderId", "ImagePath", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1997, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tato", 1, "Path to his image", "Topuria", "00000000000" },
                    { 2, 1, new DateTime(1997, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophio", 2, "Path to her image", "Khopheria", "00000000000" },
                    { 3, 1, new DateTime(1993, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikheil", 1, "Path to his image", "Topuria", "00000000000" },
                    { 4, 2, new DateTime(1993, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dea", 2, "Path to his image", "Tvildiani", "00000000000" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "NumberTypeId", "PersonId", "PhoneNumbers" },
                values: new object[,]
                {
                    { 1, 1, 1, "555159015" },
                    { 2, 0, 2, "555555555" },
                    { 3, 0, 3, "588888888" },
                    { 4, 0, 4, "599999999" }
                });

            migrationBuilder.InsertData(
                table: "RelatedPersons",
                columns: new[] { "Id", "FirstName", "LastName", "PersonId", "RelationTypeId" },
                values: new object[,]
                {
                    { 1, "Giorgi", "Giorgadze", 1, 1 },
                    { 2, "Nino", "Darsavelidze", 2, 2 },
                    { 3, "Temuri", "Tvildiani", 3, 3 },
                    { 4, "Tamta", "Mtchedlishvili", 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RelatedPersons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelatedPersons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelatedPersons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelatedPersons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
