using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataEf.Migrations
{
    public partial class product_IsDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "ActiveCode",
                value: "75a0cfa4d863411680cdb64bc7a8e47b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "ActiveCode",
                value: "ab12ba4a16b24b4c94ce70bfabec5c4e");
        }
    }
}
