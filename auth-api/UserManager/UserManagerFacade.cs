namespace UserManager;

public class UserManagerFacade(IUserRepository users) : IUserManager
{
    public async Task<bool> IsKnownUserAsync(string username, CancellationToken cancellationToken = default)
        => await users.GetUserByNameAsync(username, cancellationToken) != null;

    public Task<UserModel> CreateNewUserAsync(UserMetadata user, CancellationToken cancellationToken = default)
    {
        user.Deconstruct(out var username, out var password);

        return users.CreateNewUser(
            new(username, password.Hashify()) {
                Uuid = Guid.NewGuid(),
                Email = user.Email,
                Forename = user.Forename,
                Surname = user.Surname,
                CreatedTime = DateTime.UtcNow
            },
            cancellationToken
        );
    }
}