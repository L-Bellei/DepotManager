using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Depot.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    region = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    postal_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enterprises", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enterprises_Address",
                        column: x => x.address_id,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    sector_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    responsible_employee = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sectors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sectors_ResponsibleEmployee",
                        column: x => x.responsible_employee,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseSectors",
                columns: table => new
                {
                    enterprise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sector_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enterprise_sectors", x => new { x.enterprise_id, x.sector_id });
                    table.ForeignKey(
                        name: "fk_enterprise_sectors_enterprises_enterprise_id",
                        column: x => x.enterprise_id,
                        principalTable: "Enterprises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enterprise_sectors_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "Sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_type = table.Column<int>(type: "integer", nullable: false),
                    sector_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Sectors_SectorId",
                        column: x => x.sector_id,
                        principalTable: "Sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_addresses_postal_code_street_number",
                table: "Addresses",
                columns: new[] { "postal_code", "street", "number" });

            migrationBuilder.CreateIndex(
                name: "ix_employees_sector_id",
                table: "Employees",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "ix_enterprises_address_id",
                table: "Enterprises",
                column: "address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_enterprise_sectors_enterprise_id",
                table: "EnterpriseSectors",
                column: "enterprise_id");

            migrationBuilder.CreateIndex(
                name: "ix_enterprise_sectors_sector_id",
                table: "EnterpriseSectors",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_sector_id",
                table: "Products",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_sector_id_name",
                table: "Products",
                columns: new[] { "sector_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sectors_name",
                table: "Sectors",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_sectors_responsible_employee",
                table: "Sectors",
                column: "responsible_employee");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_sectors_sector_id",
                table: "Employees",
                column: "sector_id",
                principalTable: "Sectors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_sectors_sector_id",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EnterpriseSectors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
