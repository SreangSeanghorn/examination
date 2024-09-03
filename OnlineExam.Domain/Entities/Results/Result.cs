using System;
using System.Collections.Generic;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Domain.Entities.Results
{
    public class Result : AggregateRoot<Guid>
    {
        public Guid CandidateId { get; private set; }
        public Guid ExamId { get; private set; }
        public decimal Score { get; private set; }
        public DateTime GradedDate { get; private set; }
        public Guid GraderId { get; private set; }
        public ResultStatus Status { get; private set; }
        public string Remarks { get; private set; }

        private readonly List<ResultDetail> _resultDetails = new List<ResultDetail>();
        public IReadOnlyCollection<ResultDetail> ResultDetails => _resultDetails.AsReadOnly();


        private Result() { }

        public static Result Create(Guid candidateId, Guid examId, decimal score, DateTime gradedDate, Guid graderId, ResultStatus status, string remarks)
        {
            var result = new Result
            {
                CandidateId = candidateId,
                ExamId = examId,
                Score = score,
                GradedDate = gradedDate,
                GraderId = graderId,
                Status = status,
                Remarks = remarks
            };

            return result;
        }

        public void AddResultDetail(Guid questionId, decimal score, string feedback)
        {
            var resultDetail = new ResultDetail(Id, questionId, score, feedback);
            _resultDetails.Add(resultDetail);
        }

        // Method to publish the result
        public void PublishResult()
        {
            if (Status != ResultStatus.Released)
            {
                Status = ResultStatus.Released;
                var publishResultEvent = new ResultPublishedEvent(Id, new ResultPublishedEventData(Id, CandidateId, ExamId, Score, GradedDate));
                RaiseDomainEvents(publishResultEvent);
            }
        }
    }
}
