using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Entities.Results
{
    public class ResultPublishedEvent : DomainEvent<ResultPublishedEventData>
    {
        public ResultPublishedEvent(Guid entityId, ResultPublishedEventData content) : base(entityId, content)
        {
        }
    }
}
