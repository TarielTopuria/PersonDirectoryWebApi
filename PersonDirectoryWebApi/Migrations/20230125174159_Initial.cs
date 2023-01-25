using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonDirectoryWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Batumi" },
                    { 3, "Kutaisi" },
                    { 4, "Rustavi" },
                    { 5, "Gori" },
                    { 6, "Zugdidi" },
                    { 7, "Poti" },
                    { 8, "Kobuleti" },
                    { 9, "Khashuri" },
                    { 10, "Telavi" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "GenderId", "ImagePath", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1997, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tato", 1, "DefaultPath which will change after uploading photo", "Topuria", "00000000000" },
                    { 2, 1, new DateTime(1997, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophio", 2, "DefaultPath which will change after uploading photo", "Khopheria", "00000000000" },
                    { 3, 1, new DateTime(1993, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikheil", 1, "DefaultPath which will change after uploading photo", "Topuria", "00000000000" },
                    { 4, 2, new DateTime(1993, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dea", 2, "DefaultPath which will change after uploading photo", "Tvildiani", "00000000000" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "NumberTypeId", "PersonId", "PhoneNumbers" },
                values: new object[,]
                {
                    { 1, 1, 1, "555159015" },
                    { 2, 2, 1, "555555555" },
                    { 3, 3, 1, "588888888" },
                    { 4, 1, 2, "599999999" },
                    { 5, 1, 3, "599999998" },
                    { 6, 3, 3, "599999997" },
                    { 7, 1, 4, "599999996" }
                });

            migrationBuilder.InsertData(
                table: "RelatedPersons",
                columns: new[] { "Id", "FirstName", "LastName", "PersonId", "RelationTypeId" },
                values: new object[,]
                {
                    { 1, "Irakli", "Giorgadze", 1, 1 },
                    { 2, "Nikoloz", "Bezhitashvili", 1, 2 },
                    { 3, "Nino", "Darsavelidze", 2, 2 },
                    { 4, "Temuri", "Tvildiani", 3, 3 },
                    { 5, "Tamta", "Mtchedlishvili", 4, 4 },
                    { 6, "Giorgi", "Kopadze", 4, 2 },
                    { 7, "Giorgi", "Megreli", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                table: "PhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_PersonId",
                table: "RelatedPersons",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "RelatedPersons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
