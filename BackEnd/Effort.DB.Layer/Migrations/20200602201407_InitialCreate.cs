using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Effort.DB.Layer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "effort");

            migrationBuilder.CreateTable(
                name: "activity_type",
                schema: "effort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "timesheet",
                schema: "effort",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ActivityTypeId = table.Column<int>(nullable: false),
                    UserUniqueName = table.Column<string>(maxLength: 250, nullable: false),
                    WorkItemId = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 2, 23, 14, 6, 669, DateTimeKind.Local).AddTicks(4681)),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 2, 23, 14, 6, 662, DateTimeKind.Local).AddTicks(7079))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheet", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "activity_type",
                columns: new[] { "Id", "Code", "Color", "Comment", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "analyze", "red", "Анализ задачи", false, "Анализ" },
                    { 2, "develop", "green", "Разработка", false, "Разработка" },
                    { 3, "test", "blue", "Тестирование", false, "Тестирование" }
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -1L, 1, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(2685), 15, true, "ivan.varnavskiy@shtormtech.ru", 11 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -2L, 1, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4468), 15, false, "ivan.varnavskiy@shtormtech.ru", 6 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -3L, 1, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4478), 15, false, "ivan.varnavskiy@shtormtech.ru", 10 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -4L, 2, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4479), 15, true, "ivan.varnavskiy@shtormtech.ru", 44 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -5L, 2, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4483), 15, false, "ivan.varnavskiy@shtormtech.ru", 55 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -6L, 2, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4484), 15, false, "ivan.varnavskiy@shtormtech.ru", 66 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -7L, 2, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4485), 15, false, "ivan.varnavskiy@shtormtech.ru", 11 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -8L, 3, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4486), 15, true, "ivan.varnavskiy@shtormtech.ru", 88 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -9L, 3, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4488), 15, false, "ivan.varnavskiy@shtormtech.ru", 99 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -10L, 3, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4490), 15, false, "ivan.varnavskiy@shtormtech.ru", 100 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -11L, 3, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4493), 15, false, "ivan.varnavskiy@shtormtech.ru", 110 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -12L, 3, "текст", new DateTime(2020, 6, 2, 23, 14, 6, 671, DateTimeKind.Local).AddTicks(4494), 15, false, "ivan.varnavskiy@shtormtech.ru", 120 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_type",
                schema: "effort");

            migrationBuilder.DropTable(
                name: "timesheet",
                schema: "effort");
        }
    }
}
