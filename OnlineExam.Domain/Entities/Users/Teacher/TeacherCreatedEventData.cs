namespace OnlineExam.Domain.Entities.Users.Teacher;

public partial class TeacherCreatedEvent
{
    public class TeacherCreatedEventData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
    }
}

