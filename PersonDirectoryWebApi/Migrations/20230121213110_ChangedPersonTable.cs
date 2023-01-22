using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectoryWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Persons",
                newName: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Persons",
                newName: "Gender");
        }
    }
}
