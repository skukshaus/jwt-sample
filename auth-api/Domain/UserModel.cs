namespace Domain;

public record UserModel(string Username, string Password) : UserMetadata(Username, Password), IHaveRefreshTokens
{
    public Guid Uuid { get; init; }

    public DateTime CreatedTime { get; init; }
    public DateTime LastUpdate { get; init; }

    public FrozenSet<RefreshTokenModel> RefreshTokens { get; init; } = FrozenSet<RefreshTokenModel>.Empty;
}