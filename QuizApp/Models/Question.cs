using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Option1 { get; set; }

        [Required]
        public string Option2 { get; set; }

        [Required]
        public string Option3 { get; set; }

        [Required]
        public string Option4 { get; set; }

        [Required]
        public int CorrectAnswerIndex { get; set; }

        // NotMapped attribute tells Entity Framework to ignore this property
        [NotMapped]
        public List<string> Options
        {
            get
            {
                return new List<string> { Option1, Option2, Option3, Option4 };
            }
            set
            {
                if (value != null && value.Count >= 4)
                {
                    Option1 = value[0];
                    Option2 = value[1];
                    Option3 = value[2];
                    Option4 = value[3];
                }
            }
        }

        // Helper method to get options as a list
        public List<string> GetOptions()
        {
            return new List<string> { Option1, Option2, Option3, Option4 };
        }
    }
}