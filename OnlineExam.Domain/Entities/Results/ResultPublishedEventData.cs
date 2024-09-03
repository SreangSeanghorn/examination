namespace OnlineExam.Domain.Entities.Results
{
    public class ResultPublishedEventData
    {
        public Guid ResultId { get; }
        public Guid CandidateId { get; }
        public Guid ExamId { get; }
        public decimal Score { get; }
        public DateTime GradedDate { get; }

        public ResultPublishedEventData(Guid resultId, Guid candidateId, Guid examId, decimal score, DateTime gradedDate)
        {
            ResultId = resultId;
            CandidateId = candidateId;
            ExamId = examId;
            Score = score;
            GradedDate = gradedDate;
        }
    }
}
