namespace AuthManager.Contract;

public interface ISecurityTokenOptionFactory
{
    ISecurityTokenOptions GetAccessTokenOptions();
    ISecurityTokenOptions GetRefreshTokenOptions();
}