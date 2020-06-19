using Microsoft.EntityFrameworkCore.Migrations;

namespace EKomplet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    SalesmanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.SalesmanID);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictName = table.Column<string>(nullable: false),
                    SalesmanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictName);
                    table.ForeignKey(
                        name: "FK_Districts_Salesmen_SalesmanID",
                        column: x => x.SalesmanID,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessName = table.Column<string>(nullable: false),
                    DistrictName = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    DistrictName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => new { x.BusinessName, x.DistrictName });
                    table.ForeignKey(
                        name: "FK_Businesses_Districts_DistrictName1",
                        column: x => x.DistrictName1,
                        principalTable: "Districts",
                        principalColumn: "DistrictName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecondarySalesmens",
                columns: table => new
                {
                    SalesmanID = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: false),
                    DistrictName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondarySalesmens", x => new { x.DistrictName, x.SalesmanID });
                    table.ForeignKey(
                        name: "FK_SecondarySalesmens_Districts_DistrictName1",
                        column: x => x.DistrictName1,
                        principalTable: "Districts",
                        principalColumn: "DistrictName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondarySalesmens_Salesmen_SalesmanID",
                        column: x => x.SalesmanID,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DistrictName1",
                table: "Businesses",
                column: "DistrictName1");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_SalesmanID",
                table: "Districts",
                column: "SalesmanID");

            migrationBuilder.CreateIndex(
                name: "IX_SecondarySalesmens_DistrictName1",
                table: "SecondarySalesmens",
                column: "DistrictName1");

            migrationBuilder.CreateIndex(
                name: "IX_SecondarySalesmens_SalesmanID",
                table: "SecondarySalesmens",
                column: "SalesmanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "SecondarySalesmens");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Salesmen");
        }
    }
}
