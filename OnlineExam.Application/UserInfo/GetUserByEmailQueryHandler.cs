using OnlineExam.Application.QueriesHandler;
using OnlineExam.Domain.Repositories;

namespace OnlineExam.Application;

public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, GetUserInfoByEmailResponseDTO>
{
    private readonly IUserRepository _userRepository;
    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<GetUserInfoByEmailResponseDTO> Handle(GetUserByEmailQuery query)
    {
        var user = _userRepository.GetUserByEmailAsync(query.Email).Result;
        if (user == null)
        {
            return Task.FromResult<GetUserInfoByEmailResponseDTO>(null);
        }
        return Task.FromResult(new GetUserInfoByEmailResponseDTO
        {
            Id = user.Id,
            Email = user.Email.Value,
            Roles = user.Roles.Select(r => new RoleResponseDTO
            {
                Name = r.Name,
                Description = r.Description
            }).ToList()
        });
    }
}
