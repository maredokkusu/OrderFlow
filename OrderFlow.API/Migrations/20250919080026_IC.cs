using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow.API.Migrations
{
    /// <inheritdoc />
    public partial class IC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
