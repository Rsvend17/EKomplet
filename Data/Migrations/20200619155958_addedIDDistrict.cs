using Microsoft.EntityFrameworkCore.Migrations;

namespace EKomplet.Migrations
{
    public partial class addedIDDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Districts_DistrictName1",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondarySalesmens_Districts_DistrictName1",
                table: "SecondarySalesmens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecondarySalesmens",
                table: "SecondarySalesmens");

            migrationBuilder.DropIndex(
                name: "IX_SecondarySalesmens_DistrictName1",
                table: "SecondarySalesmens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_DistrictName1",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "SecondarySalesmens");

            migrationBuilder.DropColumn(
                name: "DistrictName1",
                table: "SecondarySalesmens");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "DistrictName1",
                table: "Businesses");

            migrationBuilder.AddColumn<int>(
                name: "DistrictID",
                table: "SecondarySalesmens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictName",
                table: "Districts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "DistrictID",
                table: "Districts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DistrictID",
                table: "Businesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecondarySalesmens",
                table: "SecondarySalesmens",
                columns: new[] { "DistrictID", "SalesmanID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DistrictID",
                table: "Businesses",
                column: "DistrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Districts_DistrictID",
                table: "Businesses",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondarySalesmens_Districts_DistrictID",
                table: "SecondarySalesmens",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Districts_DistrictID",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondarySalesmens_Districts_DistrictID",
                table: "SecondarySalesmens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecondarySalesmens",
                table: "SecondarySalesmens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_DistrictID",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "DistrictID",
                table: "SecondarySalesmens");

            migrationBuilder.DropColumn(
                name: "DistrictID",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "DistrictID",
                table: "Businesses");

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "SecondarySalesmens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DistrictName1",
                table: "SecondarySalesmens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictName",
                table: "Districts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictName1",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecondarySalesmens",
                table: "SecondarySalesmens",
                columns: new[] { "DistrictName", "SalesmanID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictName");

            migrationBuilder.CreateIndex(
                name: "IX_SecondarySalesmens_DistrictName1",
                table: "SecondarySalesmens",
                column: "DistrictName1");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DistrictName1",
                table: "Businesses",
                column: "DistrictName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Districts_DistrictName1",
                table: "Businesses",
                column: "DistrictName1",
                principalTable: "Districts",
                principalColumn: "DistrictName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondarySalesmens_Districts_DistrictName1",
                table: "SecondarySalesmens",
                column: "DistrictName1",
                principalTable: "Districts",
                principalColumn: "DistrictName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
