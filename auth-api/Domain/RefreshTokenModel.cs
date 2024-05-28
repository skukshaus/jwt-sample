namespace Domain;

public record RefreshTokenModel(
    string Token,
    DateTime ExpirationTime,
    string ClientName,
    string UserAgent,
    string RemoteAddr
);