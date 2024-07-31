namespace OnlineExam.Infrastructure;

public interface IJwtTokenGenerator
{
        string GenerateToken(Guid userId,string username);
    
}
