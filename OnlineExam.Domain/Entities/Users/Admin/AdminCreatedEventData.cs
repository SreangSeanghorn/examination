namespace OnlineExam.Domain.Entities.Users.Admin;

public record AdminCreatedEventData(
    Guid UserId,
    string Email,
    string Name
);