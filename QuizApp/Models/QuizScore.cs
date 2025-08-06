using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class QuizScore
    {
        public int Id { get; set; }
        
        public int Score { get; set; }
        
        public int TotalQuestions { get; set; }
        
        public DateTime DateTaken { get; set; }
        
        // Calculated property for percentage
        public double Percentage => TotalQuestions > 0 ? (double)Score / TotalQuestions * 100 : 0;
        
        // Calculated property for pass/fail
        public bool Passed => Score >= 8; // 80% passing grade
    }
}