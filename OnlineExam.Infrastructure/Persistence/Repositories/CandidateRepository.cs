using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities.Candidates;
using OnlineExam.Domain.Repositories.Candidates;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}