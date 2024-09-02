namespace OnlineExam.Domain.Entities.Results
{
    public class ResultDetail : Entity<Guid>
    {

        private Guid _resultDetailId;
        public Guid ResultId { get; set; }
        public Guid QuestionId { get; set; }
        public decimal Score { get; set; }
        public string Feedback { get; set; }
    }

}