namespace Domain;

public record UserModel(string Username, string Password) : UserMetadata(Username, Password), IHaveRefreshTokens
{
    public Guid Uuid { get; init; }

    public DateTime CreatedTime { get; init; }
    public DateTime LastUpdate { get; init; }

    public IReadOnlyList<RefreshTokenModel> RefreshTokens { get; init; } = new List<RefreshTokenModel>();

    public UserModel InvalidateExpiredTokens() => this with {
        RefreshTokens = [..RefreshTokens.Where(x => x.ExpirationTime > DateTime.UtcNow)]
    };
}