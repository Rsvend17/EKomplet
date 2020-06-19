using Microsoft.EntityFrameworkCore.Migrations;

namespace EKomplet.Migrations
{
    public partial class changedTablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecondarySalesmens_Districts_DistrictID",
                table: "SecondarySalesmens");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondarySalesmens_Salesmen_SalesmanID",
                table: "SecondarySalesmens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecondarySalesmens",
                table: "SecondarySalesmens");

            migrationBuilder.RenameTable(
                name: "SecondarySalesmens",
                newName: "SalesmenStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_SecondarySalesmens_SalesmanID",
                table: "SalesmenStatuses",
                newName: "IX_SalesmenStatuses_SalesmanID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Salesmen",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesmenStatuses",
                table: "SalesmenStatuses",
                columns: new[] { "DistrictID", "SalesmanID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SalesmenStatuses_Districts_DistrictID",
                table: "SalesmenStatuses",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesmenStatuses_Salesmen_SalesmanID",
                table: "SalesmenStatuses",
                column: "SalesmanID",
                principalTable: "Salesmen",
                principalColumn: "SalesmanID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesmenStatuses_Districts_DistrictID",
                table: "SalesmenStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesmenStatuses_Salesmen_SalesmanID",
                table: "SalesmenStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesmenStatuses",
                table: "SalesmenStatuses");

            migrationBuilder.RenameTable(
                name: "SalesmenStatuses",
                newName: "SecondarySalesmens");

            migrationBuilder.RenameIndex(
                name: "IX_SalesmenStatuses_SalesmanID",
                table: "SecondarySalesmens",
                newName: "IX_SecondarySalesmens_SalesmanID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Salesmen",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecondarySalesmens",
                table: "SecondarySalesmens",
                columns: new[] { "DistrictID", "SalesmanID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SecondarySalesmens_Districts_DistrictID",
                table: "SecondarySalesmens",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondarySalesmens_Salesmen_SalesmanID",
                table: "SecondarySalesmens",
                column: "SalesmanID",
                principalTable: "Salesmen",
                principalColumn: "SalesmanID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
