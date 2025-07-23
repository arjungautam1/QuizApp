using QuizApp.Helpers;
using QuizApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        // Display the home page
        public IActionResult Index()
        {
            return View();
        }

        // Start a new quiz session
        public IActionResult Start()
        {
            // Get all questions and randomly select 10
            var allQuestions = QuestionPool.GetAllQuestions();
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

            var viewModel = new QuizViewModel
            {
                CurrentQuestion = questions[currentIndex],
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
        public IActionResult Result()
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

            ViewBag.Score = correctAnswers;
            ViewBag.Total = questions.Count;
            ViewBag.Passed = correctAnswers >= 8;

            // Clear session data
            HttpContext.Session.Clear();

            return View();
        }
    }
}