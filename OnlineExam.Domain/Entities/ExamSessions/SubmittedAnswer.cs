namespace OnlineExam.Domain.Entities.ExamSessions
{
    public class SubmittedAnswer : Entity<Guid>
    {
        public Guid QuestionId { get; private set; }
        public Guid SelectedOptionId { get; private set; }

        private SubmittedAnswer() { }

        public SubmittedAnswer(Guid questionId, Guid selectedOptionId)
        {
            QuestionId = questionId;
            SelectedOptionId = selectedOptionId;

        }
    }

}