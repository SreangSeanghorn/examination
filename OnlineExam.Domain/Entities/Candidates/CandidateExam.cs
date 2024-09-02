using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities.Candidates
{
    public class CandidateExam : Entity<Guid>
    {
        public Guid CandidateId { get; private set; }
        public Guid ExamId { get; private set; }
        public bool IsCompleted { get; private set; }

        private CandidateExam() { }

        public CandidateExam(Guid candidateId, Guid examId)
        {
            CandidateId = candidateId;
            ExamId = examId;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}