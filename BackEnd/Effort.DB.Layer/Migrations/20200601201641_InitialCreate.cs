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
                    Inserted = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 1, 23, 16, 40, 570, DateTimeKind.Local).AddTicks(1077)),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 1, 23, 16, 40, 561, DateTimeKind.Local).AddTicks(4248))
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
                values: new object[] { -1L, 1, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(3280), 15, true, "iloer", 11 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -2L, 1, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5157), 15, false, "iloer", 22 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -3L, 1, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5172), 15, false, "iloer", 33 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -4L, 2, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5174), 15, true, "iloer", 44 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -5L, 2, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5178), 15, false, "iloer", 55 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -6L, 2, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5179), 15, false, "iloer", 66 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -7L, 2, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5180), 15, false, "iloer", 77 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -8L, 3, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5181), 15, true, "iloer", 88 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -9L, 3, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5182), 15, false, "iloer", 99 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -10L, 3, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5183), 15, false, "iloer", 100 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -11L, 3, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5184), 15, false, "iloer", 110 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Duration", "IsDeleted", "UserUniqueName", "WorkItemId" },
                values: new object[] { -12L, 3, "текст", new DateTime(2020, 6, 1, 23, 16, 40, 572, DateTimeKind.Local).AddTicks(5185), 15, false, "iloer", 120 });
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
