namespace Domain;

public interface IHaveRefreshTokens
{
    public IReadOnlyList<RefreshTokenModel> RefreshTokens { get; init; }
}