namespace Domain.Extensions;

public static class StringExtensions
{
    public static string Hashify(this string plainText)
    {
        var binary = Encoding.UTF8.GetBytes(plainText + "Secret_S4LT");
        var hashed = SHA256.HashData(binary);

        return Convert.ToHexString(hashed).ToLower();
    }
}