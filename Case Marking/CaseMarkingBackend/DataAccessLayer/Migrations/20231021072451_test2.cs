using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseCategories",
                columns: table => new
                {
                    CaseCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseCategories", x => x.CaseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    CourtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.CourtId);
                });

            migrationBuilder.CreateTable(
                name: "MarkedCases",
                columns: table => new
                {
                    MarkedCaseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkedCases", x => x.MarkedCaseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CaseMarkings",
                columns: table => new
                {
                    CaseMarkingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    CaseCategoryId = table.Column<int>(type: "int", nullable: false),
                    MarkingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMarkings", x => x.CaseMarkingId);
                    table.ForeignKey(
                        name: "FK_CaseMarkings_CaseCategories_CaseCategoryId",
                        column: x => x.CaseCategoryId,
                        principalTable: "CaseCategories",
                        principalColumn: "CaseCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseMarkings_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "CourtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseMarkings_CaseCategoryId",
                table: "CaseMarkings",
                column: "CaseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseMarkings_CourtId",
                table: "CaseMarkings",
                column: "CourtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseMarkings");

            migrationBuilder.DropTable(
                name: "MarkedCases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CaseCategories");

            migrationBuilder.DropTable(
                name: "Courts");
        }
    }
}
