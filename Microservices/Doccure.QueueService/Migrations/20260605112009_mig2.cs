using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doccure.QueueService.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentTime",
                table: "PatientQueues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "PatientQueues",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "PatientQueues");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "PatientQueues");
        }
    }
}
