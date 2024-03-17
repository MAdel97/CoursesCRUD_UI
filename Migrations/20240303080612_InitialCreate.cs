using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicCoursesCRUD.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academic_Courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Code = table.Column<int>(nullable: false),
                    CourseDescription = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    Course_Credit = table.Column<string>(nullable: true),
                    AcademicCoursesCourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academic_Courses", x => x.Course_ID);
                    table.ForeignKey(
                        name: "FK_Academic_Courses_Academic_Courses_AcademicCoursesCourseId",
                        column: x => x.AcademicCoursesCourseId,
                        principalTable: "Academic_Courses",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academic_Courses_AcademicCoursesCourseId",
                table: "Academic_Courses",
                column: "AcademicCoursesCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academic_Courses");
        }
    }
}
