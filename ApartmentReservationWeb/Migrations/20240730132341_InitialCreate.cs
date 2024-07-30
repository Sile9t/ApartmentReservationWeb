using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentReservationWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    TillTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CancelCondition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsCount = table.Column<int>(type: "int", nullable: false),
                    BuildingDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupancyState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupancyState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartFacility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartFacilitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartFacility_ApartFacilities_ApartFacilitiesId",
                        column: x => x.ApartFacilitiesId,
                        principalTable: "ApartFacilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentRulesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rules_ApartmentRules_ApartmentRulesId",
                        column: x => x.ApartmentRulesId,
                        principalTable: "ApartmentRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ApartmentRulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ApartmentRules_ApartmentRulesId",
                        column: x => x.ApartmentRulesId,
                        principalTable: "ApartmentRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    CapacitySquare = table.Column<double>(type: "float", nullable: false),
                    GuestsCount = table.Column<int>(type: "int", nullable: false),
                    BedsCount = table.Column<int>(type: "int", nullable: false),
                    RoomsCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    RulesId = table.Column<int>(type: "int", nullable: true),
                    RuleId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    FacilitiesInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentsInfo_ApartFacilities_FacilitiesInfoId",
                        column: x => x.FacilitiesInfoId,
                        principalTable: "ApartFacilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartmentsInfo_ApartmentRules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "ApartmentRules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartmentsInfo_HotelInfo_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartmentsInfo_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccupancyId = table.Column<int>(type: "int", nullable: false),
                    ApartmentInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_ApartmentsInfo_ApartmentInfoId",
                        column: x => x.ApartmentInfoId,
                        principalTable: "ApartmentsInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Occupancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ReservedById = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OccupancyDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EvictionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OccupancyStateId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    GuestesCount = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupancies_ApartmentsInfo_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "ApartmentsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Occupancies_OccupancyState_OccupancyStateId",
                        column: x => x.OccupancyStateId,
                        principalTable: "OccupancyState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Occupancies_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occupancies_Users_ReservedById",
                        column: x => x.ReservedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ReservedById = table.Column<int>(type: "int", nullable: false),
                    OccupancyId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    ExtraCharge = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationDates_ApartmentsInfo_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "ApartmentsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationDates_Occupancies_OccupancyId",
                        column: x => x.OccupancyId,
                        principalTable: "Occupancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationDates_OccupancyState_StateId",
                        column: x => x.StateId,
                        principalTable: "OccupancyState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationDates_Users_ReservedById",
                        column: x => x.ReservedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartFacility_ApartFacilitiesId",
                table: "ApartFacility",
                column: "ApartFacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsInfo_FacilitiesInfoId",
                table: "ApartmentsInfo",
                column: "FacilitiesInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsInfo_HotelId",
                table: "ApartmentsInfo",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsInfo_OwnerId",
                table: "ApartmentsInfo",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsInfo_RuleId",
                table: "ApartmentsInfo",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_ApartmentId",
                table: "Occupancies",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_OccupancyStateId",
                table: "Occupancies",
                column: "OccupancyStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_ReservedById",
                table: "Occupancies",
                column: "ReservedById");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_ReviewId",
                table: "Occupancies",
                column: "ReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDates_ApartmentId",
                table: "ReservationDates",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDates_OccupancyId",
                table: "ReservationDates",
                column: "OccupancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDates_ReservedById",
                table: "ReservationDates",
                column: "ReservedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDates_StateId",
                table: "ReservationDates",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ApartmentInfoId",
                table: "Review",
                column: "ApartmentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_ApartmentRulesId",
                table: "Rules",
                column: "ApartmentRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentRulesId",
                table: "Users",
                column: "ApartmentRulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartFacility");

            migrationBuilder.DropTable(
                name: "ReservationDates");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Occupancies");

            migrationBuilder.DropTable(
                name: "OccupancyState");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "ApartmentsInfo");

            migrationBuilder.DropTable(
                name: "ApartFacilities");

            migrationBuilder.DropTable(
                name: "HotelInfo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ApartmentRules");
        }
    }
}
