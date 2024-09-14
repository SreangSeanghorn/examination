using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Repositories.Exam;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Examination>, IExamRepository
    {
        public ExamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
   
}