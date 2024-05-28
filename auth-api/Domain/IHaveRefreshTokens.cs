namespace Domain;

public interface IHaveRefreshTokens
{
    public FrozenSet<RefreshTokenModel> RefreshTokens { get; init; }
}