using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.Migrations
{
    public partial class TicketContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    passenger_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    birthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.passenger_id);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    station_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.station_id);
                });

            migrationBuilder.CreateTable(
                name: "train",
                columns: table => new
                {
                    train_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_train", x => x.train_id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    route_id = table.Column<int>(type: "integer", nullable: false),
                    origin_id = table.Column<int>(type: "integer", nullable: true),
                    destination_id = table.Column<int>(type: "integer", nullable: true),
                    distance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.route_id);
                    table.ForeignKey(
                        name: "routes_destionationFK",
                        column: x => x.destination_id,
                        principalTable: "stations",
                        principalColumn: "station_id");
                    table.ForeignKey(
                        name: "routes_originFK",
                        column: x => x.origin_id,
                        principalTable: "stations",
                        principalColumn: "station_id");
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "integer", nullable: false),
                    train_id = table.Column<int>(type: "integer", nullable: false),
                    route_id = table.Column<int>(type: "integer", nullable: false),
                    class_id = table.Column<int>(type: "integer", nullable: false),
                    departure_time = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.schedule_id);
                    table.ForeignKey(
                        name: "schedule_classFK",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "schedules_routeFK",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "route_id");
                    table.ForeignKey(
                        name: "schedules_trainFK",
                        column: x => x.train_id,
                        principalTable: "train",
                        principalColumn: "train_id");
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "integer", nullable: false),
                    schedule_id = table.Column<int>(type: "integer", nullable: true),
                    passenger_id = table.Column<int>(type: "integer", nullable: true),
                    num_tickets = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.reservation_id);
                    table.ForeignKey(
                        name: "reservation_passengerFK",
                        column: x => x.passenger_id,
                        principalTable: "passengers",
                        principalColumn: "passenger_id");
                    table.ForeignKey(
                        name: "reservation_scheduleFK",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id");
                });

            migrationBuilder.CreateTable(
                name: "schedule_class",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "integer", nullable: false),
                    class_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schedule_class_PK", x => new { x.schedule_id, x.class_id });
                    table.ForeignKey(
                        name: "class_FK",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "schedule_FK",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_passenger_id",
                table: "reservations",
                column: "passenger_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_schedule_id",
                table: "reservations",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_destination_id",
                table: "routes",
                column: "destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_origin_id",
                table: "routes",
                column: "origin_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_class_class_id",
                table: "schedule_class",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_class_id",
                table: "schedules",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_route_id",
                table: "schedules",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_train_id",
                table: "schedules",
                column: "train_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "schedule_class");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "train");

            migrationBuilder.DropTable(
                name: "stations");
        }
    }
}
