namespace Domain;

public record UserModel(string Username, string Password) : UserLogin(Username, Password);