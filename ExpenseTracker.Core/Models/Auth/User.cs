namespace ExpenseTracker.Core.Models.Auth;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = ""; // store hashed passwords in real apps!
}
