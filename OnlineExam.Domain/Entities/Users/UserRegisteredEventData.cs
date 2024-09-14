namespace OnlineExam.Domain.Entities.Users

{
    public class UserRegisteredEventData
    {
        public UserRegisteredEventData(Guid userId, string email, string name)
        {
            UserId = userId;
            Email = email;
            Name = name;
        }

        public Guid UserId { get; }
        public string Email { get; }
        public string Name { get; }
    }
}
