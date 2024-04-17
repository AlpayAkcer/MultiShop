using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multishop.Order.Persistence.Migrations
{
    public partial class addres_tablosu__aciklama_ekleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Addresses");
        }
    }
}
