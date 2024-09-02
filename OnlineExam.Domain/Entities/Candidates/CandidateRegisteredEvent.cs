using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Entities.Candidates
{
    public class CandidateRegisteredEvent : DomainEvent<CandidareRegisteredEventData>
    {
        public CandidateRegisteredEvent(Guid entityId, CandidareRegisteredEventData content) : base(entityId, content)
        {
        }


    }
}