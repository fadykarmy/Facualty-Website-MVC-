using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_project.Migrations
{
    public partial class stdcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Students",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "Student_ID");

            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Professors",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Professors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Professors",
                newName: "ProfessorID");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Engineers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Engineers",
                newName: "Engineer_ID");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Engineers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Engineers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_ID);
                    table.ForeignKey(
                        name: "FK_Departments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordConfirmation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCreative",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentImgae = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCreative", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StudentID",
                table: "Departments",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "RegisterViewModels");

            migrationBuilder.DropTable(
                name: "StudentCreative");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Engineers");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Students",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "Student_ID",
                table: "Students",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Professors",
                newName: "Specialization");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Professors",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "ProfessorID",
                table: "Professors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Engineers",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "Engineer_ID",
                table: "Engineers",
                newName: "ID");
        }
    }
}
