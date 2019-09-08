namespace QuizApp.Models
{
    public class UserAnswer
    {
        public QuizQuestion Question { get; set; }
        public string Answer { get; set; }
        public bool IsUserAnswerCorrect => Answer?.Equals(Question?.CorrectAnswer) ?? false;
    }
}