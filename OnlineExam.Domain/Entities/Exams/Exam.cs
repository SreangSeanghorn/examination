using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Exam : AggregateRoot<Guid>
{
    private Guid _examId;
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ScheduledDate { get; set; }
    public TimeSpan Duration { get; set; }
    public ExamStatus Status { get; set; }
    public List<Question> Questions { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }

}

}