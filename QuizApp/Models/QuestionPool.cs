using QuizApp.Models;

namespace QuizApp.Models
{
    public static class QuestionPool
    {
        // Static method to provide all available questions
        public static List<Question> GetAllQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Text = "Which programming language is known as the 'mother of all languages'?",
                    Options = new List<string> { "Java", "C", "Python", "Assembly" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 2,
                    Text = "What does HTML stand for?",
                    Options = new List<string> { "Hyper Text Markup Language", "High Tech Modern Language", "Home Tool Markup Language", "Hyperlink and Text Markup Language" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 3,
                    Text = "Which data structure uses LIFO (Last In First Out) principle?",
                    Options = new List<string> { "Queue", "Stack", "Array", "Linked List" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 4,
                    Text = "What is the time complexity of binary search?",
                    Options = new List<string> { "O(n)", "O(n²)", "O(log n)", "O(1)" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 5,
                    Text = "Which company developed the Java programming language?",
                    Options = new List<string> { "Microsoft", "Apple", "Sun Microsystems", "IBM" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 6,
                    Text = "What does SQL stand for?",
                    Options = new List<string> { "Structured Query Language", "Simple Query Language", "Sequential Query Language", "Standard Query Language" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 7,
                    Text = "Which of the following is NOT an object-oriented programming concept?",
                    Options = new List<string> { "Encapsulation", "Compilation", "Inheritance", "Polymorphism" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 8,
                    Text = "What is the base of the binary number system?",
                    Options = new List<string> { "2", "8", "10", "16" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 9,
                    Text = "Which sorting algorithm has the best average-case time complexity?",
                    Options = new List<string> { "Bubble Sort", "Quick Sort", "Selection Sort", "Insertion Sort" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 10,
                    Text = "What does CPU stand for?",
                    Options = new List<string> { "Computer Personal Unit", "Central Processing Unit", "Control Processing Unit", "Central Program Unit" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 11,
                    Text = "Which of the following is a NoSQL database?",
                    Options = new List<string> { "MySQL", "PostgreSQL", "MongoDB", "Oracle" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 12,
                    Text = "What is the size of an int data type in C# (on most systems)?",
                    Options = new List<string> { "2 bytes", "4 bytes", "8 bytes", "16 bytes" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 13,
                    Text = "Which protocol is used to transfer files over the internet?",
                    Options = new List<string> { "HTTP", "SMTP", "FTP", "POP3" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Id = 14,
                    Text = "What does API stand for?",
                    Options = new List<string> { "Application Programming Interface", "Advanced Programming Interface", "Application Process Integration", "Automated Programming Interface" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 15,
                    Text = "Which of the following is NOT a programming paradigm?",
                    Options = new List<string> { "Object-Oriented", "Functional", "Procedural", "Diagonal" },
                    CorrectAnswerIndex = 3
                },
                new Question
                {
                    Id = 16,
                    Text = "What is the primary purpose of an index in a database?",
                    Options = new List<string> { "Store data", "Speed up queries", "Encrypt data", "Backup data" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 17,
                    Text = "Which data structure is used to implement recursion?",
                    Options = new List<string> { "Queue", "Stack", "Array", "Tree" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Id = 18,
                    Text = "What does MVC stand for in web development?",
                    Options = new List<string> { "Model View Controller", "Multi View Container", "Main Visual Component", "Model Virtual Container" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 19,
                    Text = "Which of the following is a version control system?",
                    Options = new List<string> { "Git", "Docker", "Jenkins", "Kubernetes" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Id = 20,
                    Text = "What is the decimal equivalent of binary number 1010?",
                    Options = new List<string> { "8", "9", "10", "11" },
                    CorrectAnswerIndex = 2
                }
            };
        }
    }
}