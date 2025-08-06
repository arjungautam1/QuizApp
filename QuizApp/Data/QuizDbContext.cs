using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizScore> QuizScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "Which programming language is known as the 'mother of all languages'?",
                    Option1 = "Java",
                    Option2 = "C",
                    Option3 = "Python",
                    Option4 = "Assembly",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 2,
                    Text = "What does HTML stand for?",
                    Option1 = "Hyper Text Markup Language",
                    Option2 = "High Tech Modern Language",
                    Option3 = "Home Tool Markup Language",
                    Option4 = "Hyperlink and Text Markup Language",
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 3,
                    Text = "Which data structure uses LIFO (Last In First Out) principle?",
                    Option1 = "Queue",
                    Option2 = "Stack",
                    Option3 = "Array",
                    Option4 = "Linked List",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 4,
                    Text = "What is the time complexity of binary search?",
                    Option1 = "O(n)",
                    Option2 = "O(n²)",
                    Option3 = "O(log n)",
                    Option4 = "O(1)",
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 5,
                    Text = "Which company developed the Java programming language?",
                    Option1 = "Microsoft",
                    Option2 = "Apple",
                    Option3 = "Sun Microsystems",
                    Option4 = "IBM",
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 6,
                    Text = "What does SQL stand for?",
                    Option1 = "Structured Query Language",
                    Option2 = "Simple Query Language",
                    Option3 = "Sequential Query Language",
                    Option4 = "Standard Query Language",
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 7,
                    Text = "Which of the following is NOT an object-oriented programming concept?",
                    Option1 = "Encapsulation",
                    Option2 = "Compilation",
                    Option3 = "Inheritance",
                    Option4 = "Polymorphism",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 8,
                    Text = "What is the base of the binary number system?",
                    Option1 = "2",
                    Option2 = "8",
                    Option3 = "10",
                    Option4 = "16",
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 9,
                    Text = "Which sorting algorithm has the best average-case time complexity?",
                    Option1 = "Bubble Sort",
                    Option2 = "Quick Sort",
                    Option3 = "Selection Sort",
                    Option4 = "Insertion Sort",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 10,
                    Text = "What does CPU stand for?",
                    Option1 = "Computer Personal Unit",
                    Option2 = "Central Processing Unit",
                    Option3 = "Control Processing Unit",
                    Option4 = "Central Program Unit",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 11,
                    Text = "Which of the following is a NoSQL database?",
                    Option1 = "MySQL",
                    Option2 = "PostgreSQL",
                    Option3 = "MongoDB",
                    Option4 = "Oracle",
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 12,
                    Text = "What is the size of an int data type in C# (on most systems)?",
                    Option1 = "2 bytes",
                    Option2 = "4 bytes",
                    Option3 = "8 bytes",
                    Option4 = "16 bytes",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 13,
                    Text = "Which protocol is used to transfer files over the internet?",
                    Option1 = "HTTP",
                    Option2 = "SMTP",
                    Option3 = "FTP",
                    Option4 = "POP3",
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 14,
                    Text = "What does API stand for?",
                    Option1 = "Application Programming Interface",
                    Option2 = "Advanced Programming Interface",
                    Option3 = "Application Process Integration",
                    Option4 = "Automated Programming Interface",
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 15,
                    Text = "Which of the following is NOT a programming paradigm?",
                    Option1 = "Object-Oriented",
                    Option2 = "Functional",
                    Option3 = "Procedural",
                    Option4 = "Diagonal",
                    CorrectAnswerIndex = 3
                },
                new Question
                {
                    Id = 16,
                    Text = "What is the primary purpose of an index in a database?",
                    Option1 = "Store data",
                    Option2 = "Speed up queries",
                    Option3 = "Encrypt data",
                    Option4 = "Backup data",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 17,
                    Text = "Which data structure is used to implement recursion?",
                    Option1 = "Queue",
                    Option2 = "Stack",
                    Option3 = "Array",
                    Option4 = "Tree",
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 18,
                    Text = "What does MVC stand for in web development?",
                    Option1 = "Model View Controller",
                    Option2 = "Multi View Container",
                    Option3 = "Main Visual Component",
                    Option4 = "Model Virtual Container",
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 19,
                    Text = "Which of the following is a version control system?",
                    Option1 = "Git",
                    Option2 = "Docker",
                    Option3 = "Jenkins",
                    Option4 = "Kubernetes",
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 20,
                    Text = "What is the decimal equivalent of binary number 1010?",
                    Option1 = "8",
                    Option2 = "9",
                    Option3 = "10",
                    Option4 = "11",
                    CorrectAnswerIndex = 2
                }
            );
        }
    }
}