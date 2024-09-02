using OnlineExam.Application.Queries;

namespace OnlineExam.Application;

public class GetUserByEmailQuery : IQuery<GetUserInfoByEmailResponseDTO>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
}

