using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Values.Candidates
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        private Email() { }

        public Email(string address)
        {
            // Add validation for email format
            Address = address;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }
    }

}