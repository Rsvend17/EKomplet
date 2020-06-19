using Microsoft.EntityFrameworkCore.Migrations;

namespace EKomplet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictName);
                });

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
                name: "Businesses",
                columns: table => new
                {
                    BusinessID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(nullable: true),
                    DistrictName = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    DistrictName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessID);
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
                    Status = table.Column<int>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SalesmenInBusinesses",
                columns: table => new
                {
                    BusinessID = table.Column<int>(nullable: false),
                    SalesmanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesmenInBusinesses", x => new { x.BusinessID, x.SalesmanID });
                    table.ForeignKey(
                        name: "FK_SalesmenInBusinesses_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesmenInBusinesses_Salesmen_SalesmanID",
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
                name: "IX_SalesmenInBusinesses_SalesmanID",
                table: "SalesmenInBusinesses",
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
                name: "SalesmenInBusinesses");

            migrationBuilder.DropTable(
                name: "SecondarySalesmens");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
