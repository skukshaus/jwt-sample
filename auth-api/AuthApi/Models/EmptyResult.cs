namespace AuthApi.Models;

public record EmptyResult
{
    public DateTime ServerTime = DateTime.UtcNow;
}