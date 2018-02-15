using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LibraryData.Migrations
{
    public partial class addintialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "librayBranchId",
                table: "pattrons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "librayCardId",
                table: "pattrons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LibraryBranchs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    Telephone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Fees = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchHourSS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: true),
                    CloseTime = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    OpenTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHourSS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchHourSS_LibraryBranchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "LibraryBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryAssets",
                columns: table => new
                {
                    Author = table.Column<string>(nullable: true),
                    DeweyIndex = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    cost = table.Column<decimal>(nullable: false),
                    Director = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_LibraryBranchs_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LibraryBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckedIn = table.Column<DateTime>(nullable: true),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    libraryAssetId = table.Column<int>(nullable: false),
                    libraryCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistorys_LibraryAssets_libraryAssetId",
                        column: x => x.libraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistorys_LibraryCards_libraryCardId",
                        column: x => x.libraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Since = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false),
                    libraryAssetId = table.Column<int>(nullable: true),
                    libraryCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryAssets_libraryAssetId",
                        column: x => x.libraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryCards_libraryCardId",
                        column: x => x.libraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoldPlaced = table.Column<DateTime>(nullable: false),
                    libraryAssetId = table.Column<int>(nullable: true),
                    libraryCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryAssets_libraryAssetId",
                        column: x => x.libraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryCards_libraryCardId",
                        column: x => x.libraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pattrons_librayBranchId",
                table: "pattrons",
                column: "librayBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_pattrons_librayCardId",
                table: "pattrons",
                column: "librayCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHourSS_BranchId",
                table: "BranchHourSS",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistorys_libraryAssetId",
                table: "CheckoutHistorys",
                column: "libraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistorys_libraryCardId",
                table: "CheckoutHistorys",
                column: "libraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_libraryAssetId",
                table: "Checkouts",
                column: "libraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_libraryCardId",
                table: "Checkouts",
                column: "libraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_libraryAssetId",
                table: "Holds",
                column: "libraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_libraryCardId",
                table: "Holds",
                column: "libraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_LocationId",
                table: "LibraryAssets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_StatusId",
                table: "LibraryAssets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_pattrons_LibraryBranchs_librayBranchId",
                table: "pattrons",
                column: "librayBranchId",
                principalTable: "LibraryBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pattrons_LibraryCards_librayCardId",
                table: "pattrons",
                column: "librayCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pattrons_LibraryBranchs_librayBranchId",
                table: "pattrons");

            migrationBuilder.DropForeignKey(
                name: "FK_pattrons_LibraryCards_librayCardId",
                table: "pattrons");

            migrationBuilder.DropTable(
                name: "BranchHourSS");

            migrationBuilder.DropTable(
                name: "CheckoutHistorys");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "LibraryAssets");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "LibraryBranchs");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_pattrons_librayBranchId",
                table: "pattrons");

            migrationBuilder.DropIndex(
                name: "IX_pattrons_librayCardId",
                table: "pattrons");

            migrationBuilder.DropColumn(
                name: "librayBranchId",
                table: "pattrons");

            migrationBuilder.DropColumn(
                name: "librayCardId",
                table: "pattrons");
        }
    }
}
