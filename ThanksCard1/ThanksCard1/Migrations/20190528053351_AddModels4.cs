using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ThanksCard1.Migrations
{
    public partial class AddModels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Busyoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CD = table.Column<int>(nullable: false),
                    BusyoName = table.Column<string>(nullable: true),
                    Power = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busyoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CD = table.Column<int>(nullable: false),
                    WorkRelation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CD = table.Column<int>(nullable: false),
                    KaName = table.Column<string>(nullable: true),
                    BusyoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kas_Busyoes_BusyoId",
                        column: x => x.BusyoId,
                        principalTable: "Busyoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CD = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameKana = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    KaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Kas_KaId",
                        column: x => x.KaId,
                        principalTable: "Kas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TNKCDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CD = table.Column<int>(nullable: false),
                    DateSend = table.Column<DateTime>(nullable: false),
                    DateHelp = table.Column<DateTime>(nullable: false),
                    EmployeeToId = table.Column<int>(nullable: true),
                    EmployeeFromId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    WorkId = table.Column<int>(nullable: true),
                    Look = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TNKCDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TNKCDs_Employees_EmployeeFromId",
                        column: x => x.EmployeeFromId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TNKCDs_Employees_EmployeeToId",
                        column: x => x.EmployeeToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TNKCDs_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_KaId",
                table: "Employees",
                column: "KaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kas_BusyoId",
                table: "Kas",
                column: "BusyoId");

            migrationBuilder.CreateIndex(
                name: "IX_TNKCDs_EmployeeFromId",
                table: "TNKCDs",
                column: "EmployeeFromId");

            migrationBuilder.CreateIndex(
                name: "IX_TNKCDs_EmployeeToId",
                table: "TNKCDs",
                column: "EmployeeToId");

            migrationBuilder.CreateIndex(
                name: "IX_TNKCDs_WorkId",
                table: "TNKCDs",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TNKCDs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Kas");

            migrationBuilder.DropTable(
                name: "Busyoes");
        }
    }
}
