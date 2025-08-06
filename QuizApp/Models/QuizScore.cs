using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class QuizScore
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int TotalQuestions { get; set; }

        [Required]
        public DateTime DateTaken { get; set; }

        // Calculate percentage
        public double Percentage => (double)Score / TotalQuestions * 100;
    }
}