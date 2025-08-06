using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Helpers;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizDbContext _context;

        public QuizController(QuizDbContext context)
        {
            _context = context;
        }

        // Start a new quiz session
        public async Task<IActionResult> Start()
        {
            // Get all questions from database
            var allQuestions = await _context.Questions.ToListAsync();

            // Randomly select 10 questions
            var random = new Random();
            var selectedQuestions = allQuestions.OrderBy(x => random.Next()).Take(10).ToList();

            // Store quiz data in session
            HttpContext.Session.SetObjectAsJson("QuizQuestions", selectedQuestions);
            HttpContext.Session.SetObjectAsJson("UserAnswers", new int?[10]);
            HttpContext.Session.SetInt32("CurrentIndex", 0);

            return RedirectToAction("Question");
        }

        // Display current question
        public IActionResult Question()
        {
            var questions = HttpContext.Session.GetObjectFromJson<List<Question>>("QuizQuestions");
            var currentIndex = HttpContext.Session.GetInt32("CurrentIndex") ?? 0;
            var userAnswers = HttpContext.Session.GetObjectFromJson<int?[]>("UserAnswers");

            if (questions == null || questions.Count == 0)
            {
                return RedirectToAction("Start");
            }

            var currentQuestion = questions[currentIndex];
            var viewModel = new QuizViewModel
            {
                CurrentQuestion = new Question
                {
                    Id = currentQuestion.Id,
                    Text = currentQuestion.Text,
                    Options = currentQuestion.GetOptions(),
                    CorrectAnswerIndex = currentQuestion.CorrectAnswerIndex
                },
                CurrentQuestionIndex = currentIndex,
                TotalQuestions = questions.Count,
                SelectedAnswer = userAnswers?[currentIndex]
            };

            return View(viewModel);
        }

        // Handle answer submission and navigation
        [HttpPost]
        public IActionResult SubmitAnswer(int? selectedAnswer, string action)
        {
            var currentIndex = HttpContext.Session.GetInt32("CurrentIndex") ?? 0;
            var userAnswers = HttpContext.Session.GetObjectFromJson<int?[]>("UserAnswers") ?? new int?[10];
            var questions = HttpContext.Session.GetObjectFromJson<List<Question>>("QuizQuestions");

            // Save the current answer
            if (selectedAnswer.HasValue)
            {
                userAnswers[currentIndex] = selectedAnswer.Value;
                HttpContext.Session.SetObjectAsJson("UserAnswers", userAnswers);
            }

            // Handle navigation
            switch (action)
            {
                case "Previous":
                    if (currentIndex > 0)
                    {
                        HttpContext.Session.SetInt32("CurrentIndex", currentIndex - 1);
                    }
                    return RedirectToAction("Question");

                case "Next":
                    if (currentIndex < questions.Count - 1)
                    {
                        HttpContext.Session.SetInt32("CurrentIndex", currentIndex + 1);
                        return RedirectToAction("Question");
                    }
                    else
                    {
                        return RedirectToAction("Submit");
                    }

                case "Submit":
                    return RedirectToAction("Result");

                default:
                    return RedirectToAction("Question");
            }
        }

        // Display submission confirmation page
        public IActionResult Submit()
        {
            var userAnswers = HttpContext.Session.GetObjectFromJson<int?[]>("UserAnswers");
            var answeredCount = userAnswers?.Count(a => a.HasValue) ?? 0;
            var totalQuestions = userAnswers?.Length ?? 0;

            ViewBag.AnsweredCount = answeredCount;
            ViewBag.TotalQuestions = totalQuestions;

            return View();
        }

        // Calculate and display results
        public async Task<IActionResult> Result()
        {
            var questions = HttpContext.Session.GetObjectFromJson<List<Question>>("QuizQuestions");
            var userAnswers = HttpContext.Session.GetObjectFromJson<int?[]>("UserAnswers");

            if (questions == null || userAnswers == null)
            {
                return RedirectToAction("Start");
            }

            // Calculate score
            int correctAnswers = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                if (userAnswers[i] == questions[i].CorrectAnswerIndex)
                {
                    correctAnswers++;
                }
            }

            // Save score to database
            var quizScore = new QuizScore
            {
                Score = correctAnswers,
                TotalQuestions = questions.Count,
                DateTaken = DateTime.Now
            };

            _context.QuizScores.Add(quizScore);
            await _context.SaveChangesAsync();

            ViewBag.Score = correctAnswers;
            ViewBag.Total = questions.Count;
            ViewBag.Passed = correctAnswers >= 8;

            // Clear session data
            HttpContext.Session.Clear();

            return View();
        }

        // View past scores
        public async Task<IActionResult> PastScores()
        {
            var scores = await _context.QuizScores
                .OrderByDescending(s => s.DateTaken)
                .ToListAsync();

            return View(scores);
        }
    }
}