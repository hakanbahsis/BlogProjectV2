using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_addVisitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5df50db0-81f0-424e-a4ee-8d4d6abc6b82"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("67e372a4-4f3d-4dd2-8a41-1fe24fbb7f2d"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("98c06a61-d6f3-41eb-8bd2-0260e73ce92a"), new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 12, 7, 16, 40, 7, 467, DateTimeKind.Local).AddTicks(932), null, null, new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("4505611c-4ddd-46da-9fb8-32d402eca8d3"), 15 },
                    { new Guid("993d4733-ab2e-463d-9bab-423fb8459c36"), new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 12, 7, 16, 40, 7, 467, DateTimeKind.Local).AddTicks(939), null, null, new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("0c9c10a3-c42b-4e04-bf62-ab69a366ebe1"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97bda5d3-5cd6-4cb8-a4f2-3871407f8e2c"),
                column: "ConcurrencyStamp",
                value: "87d1fca2-e5a4-4176-a805-b3d0885e3d50");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6ca339a-f8a4-4c50-afd5-83e9a3c7a1c8"),
                column: "ConcurrencyStamp",
                value: "2d4bf2f2-1d8e-4727-bfc6-3f6fdd7d3616");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6f02c99-b838-4d6e-98bc-4cfff4ed5df7"),
                column: "ConcurrencyStamp",
                value: "a1d2604d-29d2-4101-8fdb-cf321ef77eb0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c9c10a3-c42b-4e04-bf62-ab69a366ebe1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8cf61a8-e615-4728-87ca-d915e42a8371", "AQAAAAEAACcQAAAAEAnzGbLM2sTYHWs6+S9hXr1CmJfwKI4TGi9uahVP+t7jr5HGF/XciXPV8GnIFhg2Dw==", "e4c03aef-ae44-4f96-8b3c-408648890913" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4505611c-4ddd-46da-9fb8-32d402eca8d3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e73d7c84-4d78-4171-a78b-b1dece8961e7", "AQAAAAEAACcQAAAAECJy5vhIyaSmbWy2m57K5pbc4JvlSSckoes3rQU4hpn5Cn/z0h24QwYmho4+DxjHAg==", "87fc7b3c-75bc-4a2c-8291-e57e13248a12" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 16, 40, 7, 467, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 16, 40, 7, 467, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 16, 40, 7, 467, DateTimeKind.Local).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 16, 40, 7, 467, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("98c06a61-d6f3-41eb-8bd2-0260e73ce92a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("993d4733-ab2e-463d-9bab-423fb8459c36"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("5df50db0-81f0-424e-a4ee-8d4d6abc6b82"), new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 24, 23, 36, 5, 533, DateTimeKind.Local).AddTicks(7815), null, null, new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("4505611c-4ddd-46da-9fb8-32d402eca8d3"), 15 },
                    { new Guid("67e372a4-4f3d-4dd2-8a41-1fe24fbb7f2d"), new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Admin Test", new DateTime(2023, 11, 24, 23, 36, 5, 533, DateTimeKind.Local).AddTicks(7825), null, null, new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("0c9c10a3-c42b-4e04-bf62-ab69a366ebe1"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97bda5d3-5cd6-4cb8-a4f2-3871407f8e2c"),
                column: "ConcurrencyStamp",
                value: "918c93e3-1866-4d69-bba9-375bf38b62aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6ca339a-f8a4-4c50-afd5-83e9a3c7a1c8"),
                column: "ConcurrencyStamp",
                value: "af0f3dd9-d400-4c64-9374-b7a20e909299");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6f02c99-b838-4d6e-98bc-4cfff4ed5df7"),
                column: "ConcurrencyStamp",
                value: "c925e352-43d5-4066-bc37-d138ea107a0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c9c10a3-c42b-4e04-bf62-ab69a366ebe1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d222d501-1778-407d-b12e-82d6ce3e2aaf", "AQAAAAIAAYagAAAAEJhNI2gLQ5+ljqgjKQN3NMKk17vV7Bhmwzw1AMC/kdtbUR68YZu62FI9Mljk62+c/A==", "41d05d03-bb6b-4247-afe5-2dab907a1b64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4505611c-4ddd-46da-9fb8-32d402eca8d3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8821dcf-86fb-4bed-bca7-0c0bdcd515f7", "AQAAAAIAAYagAAAAEGvJIfgpD5Vio7GYcSs4Nh4lBnTpMFNufr3qyhr9lhuzFTXeL+eMldcjrKKyymhMDg==", "f5bc6252-739b-4a6d-9a4e-da0297541b9e" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 23, 36, 5, 533, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 23, 36, 5, 533, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 23, 36, 5, 533, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 23, 36, 5, 533, DateTimeKind.Local).AddTicks(8537));
        }
    }
}
