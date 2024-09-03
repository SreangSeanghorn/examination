using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Domain.Entities.ExamSessions
{
    public class ExamSession : AggregateRoot<Guid>
    {
        public Guid CandidateId { get; private set; }
        public Guid ExamId { get; private set; }
        private List<SubmittedAnswer> _submittedAnswers = new List<SubmittedAnswer>();
        public IReadOnlyCollection<SubmittedAnswer> SubmittedAnswers => _submittedAnswers.AsReadOnly();

        private ExamSession() { }

        public ExamSession(Guid candidateId, Guid examId)
        {
            CandidateId = candidateId;
            ExamId = examId;
        }

        public static ExamSession StartExam(Guid candidateId, Guid examId)
        {
            var examSession = new ExamSession(candidateId, examId);
            examSession.RaiseDomainEvents(new ExamSessionStartedEvent(examSession));
            return examSession;
        }


        public void SubmitAnswer(Guid questionId, Guid selectedOptionId)
        {
            var answer = new SubmittedAnswer(questionId, selectedOptionId);
            _submittedAnswers.Add(answer);
        }
    }

}