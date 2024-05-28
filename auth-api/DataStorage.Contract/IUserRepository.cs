namespace DataStorage.Contract;

public interface IUserRepository
{
    Task<IReadOnlyList<UserModel>> GetAll(CancellationToken cancellationToken);
    Task<UserModel?> GetUserByNameAsync(string username, CancellationToken cancellationToken);
    Task<UserModel?> GetUserByLoginAsync(UserLogin login, CancellationToken cancellationToken);
    Task<UserModel> CreateNewUser(UserModel user, CancellationToken cancellationToken);
    Task<UserModel> UpdateUserAsync(UserModel user, CancellationToken cancellationToken);
}