using System;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Interfaces.Repository;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories;

public class ExamRepository : GenericRepository<Examination>, IExamRepository
{
    public ExamRepository(ApplicationDbContext context) : base(context)
    {
    }
    
}
