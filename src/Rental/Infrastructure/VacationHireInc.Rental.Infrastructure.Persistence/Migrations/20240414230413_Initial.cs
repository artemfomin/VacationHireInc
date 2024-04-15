using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationHireInc.Rental.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rental");

            migrationBuilder.CreateTable(
                name: "Minivans",
                schema: "rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SomeMinivanSpecificProperty = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Mark = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<uint>(type: "INTEGER", nullable: false),
                    Gear = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Vin = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentPrice = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    PassengerCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minivans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualifiedTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RentCost = table.Column<double>(type: "REAL", nullable: false),
                    BillingPeriod = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RentItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RentStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sedans",
                schema: "rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SomeSedanSpecificProperty = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Mark = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<uint>(type: "INTEGER", nullable: false),
                    Gear = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Vin = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentPrice = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    PassengerCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceInstitution = table.Column<string>(type: "TEXT", nullable: true),
                    NextServiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServiceSummary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                schema: "rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SomeTruckSpecificProperty = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Mark = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<uint>(type: "INTEGER", nullable: false),
                    Gear = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Vin = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentPrice = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CarryCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalChecks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FkVehicleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Issuer = table.Column<string>(type: "TEXT", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalChecks_Minivans_FkVehicleId",
                        column: x => x.FkVehicleId,
                        principalSchema: "rental",
                        principalTable: "Minivans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalChecks_Sedans_FkVehicleId",
                        column: x => x.FkVehicleId,
                        principalSchema: "rental",
                        principalTable: "Sedans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalChecks_Trucks_FkVehicleId",
                        column: x => x.FkVehicleId,
                        principalSchema: "rental",
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePassports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FkVehicleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Issuer = table.Column<string>(type: "TEXT", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePassports_Minivans_FkVehicleId",
                        column: x => x.FkVehicleId,
                        principalSchema: "rental",
                        principalTable: "Minivans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePassports_Sedans_FkVehicleId",
                        column: x => x.FkVehicleId,
                        principalSchema: "rental",
                        principalTable: "Sedans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePassports_Trucks_FkVehicleId",
                        column: x => x.FkVehicleId,
                        principalSchema: "rental",
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalChecks_FkVehicleId",
                table: "TechnicalChecks",
                column: "FkVehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePassports_FkVehicleId",
                table: "VehiclePassports",
                column: "FkVehicleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentItems");

            migrationBuilder.DropTable(
                name: "RentOrders");

            migrationBuilder.DropTable(
                name: "ServiceRecords");

            migrationBuilder.DropTable(
                name: "TechnicalChecks");

            migrationBuilder.DropTable(
                name: "VehiclePassports");

            migrationBuilder.DropTable(
                name: "Minivans",
                schema: "rental");

            migrationBuilder.DropTable(
                name: "Sedans",
                schema: "rental");

            migrationBuilder.DropTable(
                name: "Trucks",
                schema: "rental");
        }
    }
}
