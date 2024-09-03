using System;
using OnlineExam.Domain.Entities.Candidates;
using OnlineExam.Domain.Interfaces.Repository;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories;

public class CandidateRepositoy : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepositoy(ApplicationDbContext context) : base(context)
    {
    }
    
}

