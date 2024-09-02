using OnlineExam.Domain.Values;

namespace OnlineExam.Domain.Entities.Candidates
{
    public class CandidareRegisteredEventData
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }

        public CandidareRegisteredEventData(string name, Email email)
        {
            Name = name;
            Email = email;
        }
    }
}