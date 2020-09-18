using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Producer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledTaxes",
                columns: table => new
                {
                    ScheduledTaxId = table.Column<Guid>(nullable: false),
                    Municipality = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    TaxType = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTaxes", x => x.ScheduledTaxId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledTaxes");
        }
    }
}
