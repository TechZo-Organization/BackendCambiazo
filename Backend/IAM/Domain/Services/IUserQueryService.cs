using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Domain.Model.Queries;

namespace Backend.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);

    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);

    Task<User?> Handle(GetUserByEmailQuery query);
}