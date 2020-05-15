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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
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
                    ActivityTypeId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(maxLength: 250, nullable: false),
                    WorkItemId = table.Column<long>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 7, 1, 1, 3, 18, 648, DateTimeKind.Local).AddTicks(2923)),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 7, 1, 1, 3, 18, 642, DateTimeKind.Local).AddTicks(6692))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheet", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "activity_type",
                columns: new[] { "Id", "Code", "Comment", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1L, "analyze", "Анализ задачи", false, "Анализ" },
                    { 2L, "develop", "Разработка", false, "Разработка" },
                    { 3L, "test", "Тестирование", false, "Тестирование" }
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 1L, 1L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 655, DateTimeKind.Local).AddTicks(2306), true, 15L, "iloer", 11L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 2L, 1L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9603), false, 15L, "iloer", 22L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 3L, 1L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9654), false, 15L, "iloer", 33L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 4L, 2L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9659), true, 15L, "iloer", 44L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 5L, 2L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9675), false, 15L, "iloer", 55L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 6L, 2L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9679), false, 15L, "iloer", 66L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 7L, 2L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9685), false, 15L, "iloer", 77L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 8L, 3L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9688), true, 15L, "iloer", 88L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 9L, 3L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9692), false, 15L, "iloer", 99L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 10L, 3L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9696), false, 15L, "iloer", 100L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 11L, 3L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9700), false, 15L, "iloer", 110L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 12L, 3L, "текст", new DateTime(2019, 7, 1, 1, 3, 18, 656, DateTimeKind.Local).AddTicks(9703), false, 15L, "iloer", 120L });
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
