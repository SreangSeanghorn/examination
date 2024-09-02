using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Domain.Entities.ExamSessions
{
    public class ExamSession : Entity<Guid>, IAggregateRoot
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

        public ExamSession ExamStart(Guid candidateId, Guid examId)
        {
            CandidateId = candidateId;
            ExamId = examId;
            
            return this;
        }
        public void SubmitAnswer(Guid questionId, Guid selectedOptionId)
        {
            var answer = new SubmittedAnswer(questionId, selectedOptionId);
            _submittedAnswers.Add(answer);
        }
    }

    public class SubmittedAnswer
    {
    }
}