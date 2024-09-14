using System;
using OnlineExam.Domain.Values;

namespace OnlineExam.Domain.Entities.Candidates.Services;

public interface ICandidateService
{
    Task RegisterCandidateAsync(string name, Email email, Password password);
    Task<CandidateExam> AssignExamToCandidateAsync(Guid candidateId, Guid examId);
}

