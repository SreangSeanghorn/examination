using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Values;

namespace OnlineExam.Domain.Entities.Candidates
{
    public class Candidate : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        public Candidate()
        {

        }
        public Candidate(string name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public Candidate Register(string name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
            var candidate = new Candidate(name, email, password);
            candidate.RaiseDomainEvents(new CandidateRegisteredEvent(Id, new CandidareRegisteredEventData(name, email)));
            return this;
        }

    }
}