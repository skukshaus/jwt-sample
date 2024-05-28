namespace AuthManager.Contract;

public interface ISecurityTokenOptions
{
    string GetSigningKey();
    public byte[] GetBinarySigningKey() => Encoding.UTF8.GetBytes(GetSigningKey());
    IEnumerable<Claim> GetClaims(UserModel user);
    DateTime GetExpirationTime();
}