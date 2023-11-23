using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"), "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6845), null, null, false, null, null, "Asp.Net Core" },
                    { new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"), "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6842), null, null, false, null, null, "Visual Studio" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"), "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6946), null, null, "images/testimage", "jpg", false, null, null },
                    { new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"), "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6943), null, null, "images/testimage", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("bce4549a-185b-4d84-a90d-7f687058c973"), new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6681), null, null, new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("c8afbbb2-995e-43d8-a6ab-44e312fbce83"), new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6675), null, null, new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bce4549a-185b-4d84-a90d-7f687058c973"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c8afbbb2-995e-43d8-a6ab-44e312fbce83"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"));
        }
    }
}
