using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migartions
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaskedId",
                table: "Baskets",
                newName: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Baskets",
                newName: "BaskedId");
        }
    }
}
