using Domain.Extensions;

namespace DataStorage;

public class UserRepository : IUserRepository
{
    private const string UsersJsonFilePath = "S:\\users.json";
    private ConcurrentDictionary<Guid, UserModel>? _data;

    public async Task<IReadOnlyList<UserModel>> GetAll(CancellationToken cancellationToken)
    {
        await ReadAndCacheFileStore(cancellationToken);

        return _data!.Values.ToImmutableList();
    }

    public async Task<UserModel?> GetUserByNameAsync(string username, CancellationToken cancellationToken)
        => (await GetAll(cancellationToken))
            .FirstOrDefault(x => x.Username == username);

    public async Task<UserModel?> GetUserByLoginAsync(UserLogin login, CancellationToken cancellationToken)
        => (await GetAll(cancellationToken))
            .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

    public async Task<UserModel> CreateNewUser(UserModel user, CancellationToken cancellationToken)
    {
        await ReadAndCacheFileStore(cancellationToken);

        user = user with { LastUpdate = DateTime.UtcNow };
        _data!.TryAdd(user.Uuid, user);

        await UpdateFileStore(cancellationToken);

        return user;
    }

    public async Task<UserModel> UpdateUserAsync(UserModel user, CancellationToken cancellationToken)
    {
        user = user.InvalidateExpiredTokens();
        var safeUserData = user with {
            RefreshTokens = [..user.RefreshTokens.Select(t => t with { Token = t.Token.Hashify() })]
        };

        _data!.AddOrUpdate(user.Uuid, safeUserData, (_, _) => safeUserData);

        await UpdateFileStore(cancellationToken);

        return user;
    }

    private async Task ReadAndCacheFileStore(CancellationToken cancellationToken)
    {
        if (_data != null)
        {
            return;
        }

        if (File.Exists(UsersJsonFilePath))
        {
            var jsonContent = await File.ReadAllTextAsync(UsersJsonFilePath, cancellationToken);
            var data = JsonSerializer.Deserialize<UserModel[]>(jsonContent) ?? [];
            var dict = data.ToDictionary(k => k.Uuid, v => v);

            _data = new(dict);
        }
    }

    private async Task UpdateFileStore(CancellationToken cancellationToken)
    {
        var content = JsonSerializer.Serialize(
            _data!.Values, new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                WriteIndented = true
            }
        );

        await File.WriteAllTextAsync(UsersJsonFilePath, content, cancellationToken);
    }
}