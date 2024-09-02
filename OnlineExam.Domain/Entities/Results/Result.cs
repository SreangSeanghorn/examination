using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities.Results
{
    public class Result : AggregateRoot<Guid>
    {
 
        private Guid _resultId;
        public Guid CandidateId { get; set; }
        public Guid ExamId { get; set; }
        public decimal Score { get; set; }
        public DateTime GradedDate { get; set; }
        public Guid GraderId { get; set; }
        public ResultStatus Status { get; set; }
        public string Remarks { get; set; }
        public List<ResultDetail> Details { get; set; }
    }

}