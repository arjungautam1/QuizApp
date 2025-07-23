namespace QuizApp.Models
{
    public class QuizViewModel
    {
        public Question CurrentQuestion { get; set; }
        public int CurrentQuestionIndex { get; set; }
        public int TotalQuestions { get; set; }
        public int? SelectedAnswer { get; set; }
    }
}