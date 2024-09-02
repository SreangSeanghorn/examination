namespace OnlineExam.Domain.Entities
{
    public class Option : Entity<Guid>
    {
        private Guid _optionId;
        public Guid ExamId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

    }
}