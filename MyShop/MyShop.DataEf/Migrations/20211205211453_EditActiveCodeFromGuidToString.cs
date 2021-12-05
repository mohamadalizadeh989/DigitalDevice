using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataEf.Migrations
{
    public partial class EditActiveCodeFromGuidToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActiveCode",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActiveCode",
                value: "0654fa2db6694b1f9615acbaa8a7f9aa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ActiveCode",
                table: "Users",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActiveCode",
                value: new Guid("fd07bb4b-2afe-487a-af09-39fd5cfe2c34"));
        }
    }
}
