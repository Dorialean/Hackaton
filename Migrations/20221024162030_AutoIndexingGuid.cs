using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Migrations
{
    public partial class AutoIndexingGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "user_data",
                columns: table => new
                {
                    user_data_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    last_name = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    father_name = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    user_data_class = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_data_pkey", x => x.user_data_id);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    identifier = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_login_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "lecture",
                columns: table => new
                {
                    lecture_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    lect_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecture", x => x.lecture_id);
                    table.ForeignKey(
                        name: "lecture_course_id_fkey",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "session_handler",
                columns: table => new
                {
                    session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_jwt = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("session_handler_pkey", x => x.session_id);
                    table.ForeignKey(
                        name: "session_handler_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user_login",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_lecture_course_id",
                table: "lecture",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_handler_user_id",
                table: "session_handler",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lecture");

            migrationBuilder.DropTable(
                name: "session_handler");

            migrationBuilder.DropTable(
                name: "user_data");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "user_login");
        }
    }
}
