using OnlineExam.Domain.Entities;

namespace OnlineExam.Application;

public class GetUserInfoByEmailResponseDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public List<RoleResponseDTO> Roles { get; set; }

}
