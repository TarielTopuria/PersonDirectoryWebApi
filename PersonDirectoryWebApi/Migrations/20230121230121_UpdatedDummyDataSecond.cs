using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectoryWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDummyDataSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RelatedPersons",
                columns: new[] { "Id", "FirstName", "LastName", "PersonId", "RelationTypeId" },
                values: new object[] { 5, "Giorgi", "Megreli", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelatedPersons",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
