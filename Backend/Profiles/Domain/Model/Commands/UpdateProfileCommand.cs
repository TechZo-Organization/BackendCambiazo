using Backend.Profiles.Domain.Model.ValueObjects;

namespace Backend.Profiles.Domain.Model.Commands;

public record UpdateProfileCommand(
    int Id, string Name, string Email, string Phone, string Photo, int MembershipId
    );