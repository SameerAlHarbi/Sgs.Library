using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sgs.Library.DataAccess.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Author = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    ReleaseYaer = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RowNumber = table.Column<string>(maxLength: 5, nullable: false),
                    ShelfNumber = table.Column<string>(maxLength: 5, nullable: false),
                    ColumnNumber = table.Column<string>(maxLength: 5, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ArabicName = table.Column<string>(maxLength: 500, nullable: true),
                    MapTypeId = table.Column<int>(nullable: true),
                    MapSize = table.Column<string>(maxLength: 15, nullable: true),
                    Abstract = table.Column<string>(nullable: true),
                    HasAttachment = table.Column<bool>(nullable: true),
                    Region = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PeriodicalDate = table.Column<DateTime>(nullable: true),
                    Report_Region = table.Column<string>(maxLength: 30, nullable: true),
                    ReportTypeId = table.Column<int>(nullable: true),
                    Report_HasAttachment = table.Column<bool>(nullable: true),
                    Report_Abstract = table.Column<string>(maxLength: 500, nullable: true),
                    Note = table.Column<string>(maxLength: 300, nullable: true),
                    Report_Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_MapsTypes_MapTypeId",
                        column: x => x.MapTypeId,
                        principalTable: "MapsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_ReportsTypes_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrowings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: true),
                    MapId = table.Column<int>(nullable: true),
                    ReportId = table.Column<int>(nullable: true),
                    PeriodicalId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    IsReturn = table.Column<bool>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Borrowings_Books_MapId",
                        column: x => x.MapId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Borrowings_Books_PeriodicalId",
                        column: x => x.PeriodicalId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Borrowings_Books_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_MapTypeId",
                table: "Books",
                column: "MapTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReportTypeId",
                table: "Books",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_BookId",
                table: "Borrowings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_MapId",
                table: "Borrowings",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_PeriodicalId",
                table: "Borrowings",
                column: "PeriodicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_ReportId",
                table: "Borrowings",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowings");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "MapsTypes");

            migrationBuilder.DropTable(
                name: "ReportsTypes");
        }
    }
}
