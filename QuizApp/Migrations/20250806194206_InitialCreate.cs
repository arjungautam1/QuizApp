using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswerIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizScores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswerIndex", "Option1", "Option2", "Option3", "Option4", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Java", "C", "Python", "Assembly", "Which programming language is known as the 'mother of all languages'?" },
                    { 2, 0, "Hyper Text Markup Language", "High Tech Modern Language", "Home Tool Markup Language", "Hyperlink and Text Markup Language", "What does HTML stand for?" },
                    { 3, 1, "Queue", "Stack", "Array", "Linked List", "Which data structure uses LIFO (Last In First Out) principle?" },
                    { 4, 2, "O(n)", "O(n²)", "O(log n)", "O(1)", "What is the time complexity of binary search?" },
                    { 5, 2, "Microsoft", "Apple", "Sun Microsystems", "IBM", "Which company developed the Java programming language?" },
                    { 6, 0, "Structured Query Language", "Simple Query Language", "Sequential Query Language", "Standard Query Language", "What does SQL stand for?" },
                    { 7, 1, "Encapsulation", "Compilation", "Inheritance", "Polymorphism", "Which of the following is NOT an object-oriented programming concept?" },
                    { 8, 0, "2", "8", "10", "16", "What is the base of the binary number system?" },
                    { 9, 1, "Bubble Sort", "Quick Sort", "Selection Sort", "Insertion Sort", "Which sorting algorithm has the best average-case time complexity?" },
                    { 10, 1, "Computer Personal Unit", "Central Processing Unit", "Control Processing Unit", "Central Program Unit", "What does CPU stand for?" },
                    { 11, 2, "MySQL", "PostgreSQL", "MongoDB", "Oracle", "Which of the following is a NoSQL database?" },
                    { 12, 1, "2 bytes", "4 bytes", "8 bytes", "16 bytes", "What is the size of an int data type in C# (on most systems)?" },
                    { 13, 2, "HTTP", "SMTP", "FTP", "POP3", "Which protocol is used to transfer files over the internet?" },
                    { 14, 0, "Application Programming Interface", "Advanced Programming Interface", "Application Process Integration", "Automated Programming Interface", "What does API stand for?" },
                    { 15, 3, "Object-Oriented", "Functional", "Procedural", "Diagonal", "Which of the following is NOT a programming paradigm?" },
                    { 16, 1, "Store data", "Speed up queries", "Encrypt data", "Backup data", "What is the primary purpose of an index in a database?" },
                    { 17, 1, "Queue", "Stack", "Array", "Tree", "Which data structure is used to implement recursion?" },
                    { 18, 0, "Model View Controller", "Multi View Container", "Main Visual Component", "Model Virtual Container", "What does MVC stand for in web development?" },
                    { 19, 0, "Git", "Docker", "Jenkins", "Kubernetes", "Which of the following is a version control system?" },
                    { 20, 2, "8", "9", "10", "11", "What is the decimal equivalent of binary number 1010?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuizScores");
        }
    }
}
