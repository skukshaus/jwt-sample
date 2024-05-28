namespace Domain;

public record UserMetadata(string Username, string Password) : UserLogin(Username, Password)
{
    public string Forename { get; init; } = "";
    public string Surname { get; init; } = "";
    public string Email { get; init; } = "";
}