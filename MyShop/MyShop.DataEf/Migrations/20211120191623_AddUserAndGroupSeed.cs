using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataEf.Migrations
{
    public partial class AddUserAndGroupSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "CreateDate", "LastModifyDate", "Title" },
                values: new object[] { 1, new DateTime(2021, 11, 20, 9, 57, 0, 0, DateTimeKind.Unspecified), null, "گروه اصلی" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "EmailCode", "EmailConfirm", "FullName", "IsActive", "LastModifyDate", "Mobile", "Password" },
                values: new object[] { 1, new DateTime(2021, 11, 20, 9, 57, 0, 0, DateTimeKind.Unspecified), "mohamadalizadeh989@gmail.com", new Guid("00000000-0000-0000-0000-000000000000"), true, "Mohammad Alizadeh", true, null, "09121425058", "APQYv1fPpD9GejqGh1qtaxPcc6ioAt8NdaJd85F2/ZoTQHdSADUu91NxflyVMIvceg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
