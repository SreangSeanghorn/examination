using OnlineExam.Domain.Values;

namespace OnlineExam.Domain.Entities.Candidates
{
    public class Password : ValueObject
    {
        public string Hash { get; private set; }
        public string Salt { get; private set; }

        private Password() { }

        public Password(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Hash;
            yield return Salt;
        }
    }
}