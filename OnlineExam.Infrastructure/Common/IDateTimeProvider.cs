using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Application.Common.Interface.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}