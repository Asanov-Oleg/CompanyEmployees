using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployees.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Schedule_ScheduleId",
                table: "Shipment");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Employees",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkerId",
                table: "Employees",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "ScheduleId");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Position = table.Column<string>(maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Shipment",
                columns: new[] { "ShipmentId", "Address", "ScheduleId", "ShipmentSchedule", "Time" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-15de-024705497d4a"), "585 Wall John Street, MD 21228", null, "16:37", new Guid("c9d4c053-49b6-410c-bc78-2d14a1001870") },
                    { new Guid("021ca3c1-0deb-4afd-1e94-2159a8479811"), "322 Forest Gump Avenue, BF 564", null, "19:20", new Guid("3d490a70-94ce-1d15-9494-5248210c2ce3") }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ScheduleId", "CompanyId", "EmployeeId", "Time", "WorkerId" },
                values: new object[] { new Guid("80abbca8-664d-4b20-15de-024705497d4a"), null, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "08:30", "1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ScheduleId", "CompanyId", "EmployeeId", "Time", "WorkerId" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-138c-ed49778fb52a"), null, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "10:00", "2" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ScheduleId", "CompanyId", "EmployeeId", "Time", "WorkerId" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-1e94-2159a8479811"), null, new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "14:00", "3" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employee_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Employees_ScheduleId",
                table: "Shipment",
                column: "ScheduleId",
                principalTable: "Employees",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employee_EmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Employees_ScheduleId",
                table: "Shipment");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ScheduleId",
                keyValue: new Guid("021ca3c1-0deb-4afd-1e94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ScheduleId",
                keyValue: new Guid("80abbca8-664d-4b20-15de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ScheduleId",
                keyValue: new Guid("86dba8c0-d178-41e7-138c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Shipment",
                keyColumn: "ShipmentId",
                keyValue: new Guid("021ca3c1-0deb-4afd-1e94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Shipment",
                keyColumn: "ShipmentId",
                keyValue: new Guid("80abbca8-664d-4b20-15de-024705497d4a"));

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    WorkerId = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeId",
                table: "Schedule",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Schedule_ScheduleId",
                table: "Shipment",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
