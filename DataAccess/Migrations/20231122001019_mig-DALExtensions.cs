using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migDALExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bce4549a-185b-4d84-a90d-7f687058c973"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c8afbbb2-995e-43d8-a6ab-44e312fbce83"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("07a11007-4cef-4f64-b14a-0b5016836349"), new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 22, 3, 10, 18, 868, DateTimeKind.Local).AddTicks(2478), null, null, new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("4f878183-3dd7-4c2f-8d66-41972acb693f"), new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 22, 3, 10, 18, 868, DateTimeKind.Local).AddTicks(2465), null, null, new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 3, 10, 18, 868, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 3, 10, 18, 868, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 3, 10, 18, 868, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 3, 10, 18, 868, DateTimeKind.Local).AddTicks(3196));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("07a11007-4cef-4f64-b14a-0b5016836349"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4f878183-3dd7-4c2f-8d66-41972acb693f"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("bce4549a-185b-4d84-a90d-7f687058c973"), new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6681), null, null, new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("c8afbbb2-995e-43d8-a6ab-44e312fbce83"), new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6675), null, null, new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6943));
        }
    }
}
