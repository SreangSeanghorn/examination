using System;
using OnlineExam.Domain.Entities.ExamSessions;
using OnlineExam.Domain.Interfaces.Repository;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories;

public class ExamSessionRepository : GenericRepository<ExamSession>, IExamSessionRepository
{
    public ExamSessionRepository(ApplicationDbContext context) : base(context)
    {
    }
    
}
