using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Entities.ExamSessions
{
    public class ExamSessionStartedEvent : DomainEvent<ExamSessionData>
    {
        public ExamSessionStartedEvent(ExamSession entity) : base(entity.Id, new ExamSessionData
        {
            CandidateId = entity.CandidateId,
            ExamId = entity.ExamId
        })
        {
        }
    }

}