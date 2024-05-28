namespace DataStorage;

public class UserRepository : IUserRepository
{
    private const string UsersJsonFilePath = "S:\\users.json";
    private ConcurrentBag<UserModel>? _data;

    public async Task<IReadOnlyList<UserModel>> GetAll(CancellationToken cancellationToken)
    {
        await ReadAndCacheFileStore(cancellationToken);

        return _data!.ToImmutableList();
    }

    public async Task<UserModel?> GetUserByNameAsync(string username, CancellationToken cancellationToken)
        => (await GetAll(cancellationToken))
            .FirstOrDefault(x => x.Username == username);

    public async Task<UserModel> CreateNewUser(UserModel user, CancellationToken cancellationToken)
    {
        await ReadAndCacheFileStore(cancellationToken);

        user = user with { LastUpdate = DateTime.UtcNow };
        _data!.Add(user);

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

            _data = new ConcurrentBag<UserModel>(data);


        }
    }

    private async Task UpdateFileStore(CancellationToken cancellationToken)
    {
        var content = JsonSerializer.Serialize(
            _data, new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                WriteIndented = true
            }
        );

        await File.WriteAllTextAsync(UsersJsonFilePath, content, cancellationToken);
    }
}