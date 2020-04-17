using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElasticSearchAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
