using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Question : Entity<Guid>
    {

        private Guid _questionId;
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<Option> Options { get; set; }

    }
}