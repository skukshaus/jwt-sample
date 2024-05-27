namespace AuthApi.Models;

public record MessageResult(string Message) : EmptyResult;

public record AliveMessageResult() : MessageResult("alive=true");

public record EmptyResult
{
    public DateTime ServerTime = DateTime.UtcNow;
}