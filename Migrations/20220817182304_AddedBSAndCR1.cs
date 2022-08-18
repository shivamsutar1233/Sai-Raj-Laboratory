using Microsoft.EntityFrameworkCore.Migrations;

namespace Sai_Raj_Laboratory.Migrations
{
    public partial class AddedBSAndCR1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(nullable: true),
                    PatientAge = table.Column<int>(nullable: false),
                    PatientSex = table.Column<string>(nullable: true),
                    PatientHB = table.Column<float>(nullable: false),
                    PatientWBC = table.Column<int>(nullable: false),
                    PatientNeutrophils = table.Column<int>(nullable: false),
                    PateintLymphocytes = table.Column<int>(nullable: false),
                    PateintEosinophils = table.Column<int>(nullable: false),
                    PatientMonocytes = table.Column<int>(nullable: false),
                    PatientBasophils = table.Column<int>(nullable: false),
                    PatientPlateletesCount = table.Column<int>(nullable: false),
                    PatientWBCStatus = table.Column<string>(nullable: true),
                    PatientRBCStatus = table.Column<string>(nullable: true),
                    PatientPlateletesStatus = table.Column<string>(nullable: true),
                    PatientParasitesStatus = table.Column<string>(nullable: true),
                    UHID = table.Column<string>(nullable: false),
                    PatientBS = table.Column<float>(nullable: true),
                    PatientCreatinine = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.PatientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
