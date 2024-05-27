﻿namespace UserManager.Contract;

public interface IUserManager
{
    public Task<bool> IsKnownUserAsync(string username, CancellationToken cancellationToken = default);
    public Task<UserModel> CreateNewUserAsync(UserModel user, CancellationToken cancellationToken = default);
}