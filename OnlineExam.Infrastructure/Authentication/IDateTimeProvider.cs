namespace OnlineExam.Infrastructure;

public interface IDateTimeProvider 
{
        DateTime UtcNow { get; }
}
