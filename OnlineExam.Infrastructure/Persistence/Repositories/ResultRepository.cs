using System;
using OnlineExam.Domain.Entities.Results;
using OnlineExam.Domain.Interfaces.Repository;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories;

public class ResultRepository : GenericRepository<Result>, IResultRepository
{
    public ResultRepository(ApplicationDbContext context) : base(context)
    {
    }
    
}