namespace Domain;

public record UserMetadata(string Username, string Password) : UserLogin(Username, Password)
{
    public string Email { get; init; } = "";
}