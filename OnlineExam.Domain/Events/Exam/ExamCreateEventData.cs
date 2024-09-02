namespace OnlineExam.Domain.Events
{
    public class ExamCreateEventData
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime StartDate { get; set; }
    }
}