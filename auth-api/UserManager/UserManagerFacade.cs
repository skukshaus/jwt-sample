namespace UserManager;

public class UserManagerFacade : IUserManager
{
    public Task<bool> IsKnownUserAsync(string username, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> CreateNewUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}