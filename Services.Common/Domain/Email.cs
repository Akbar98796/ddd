namespace Services.Common.Domain;

public record Email
{
    private const string EmailPattern = @"^(.+)@(.+)$";
    private const int MaxLength = 100;

    public string Value { get; private set; }

    private Email(string value) => Value = value;

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty", nameof(email));
        }

        email = email.Trim();

        if (email.Length > MaxLength)
        {
            throw new ArgumentException($"Email cannot be longer than {MaxLength} characters", nameof(email));
        }

        if (!IsEmail(email))
        {
            throw new ArgumentException("Email is invalid", nameof(email));
        }

        return new Email(email);
    }

    public static bool IsEmail(string email) => Regex.IsMatch(email, EmailPattern);


    public static implicit operator string(Email email) => email.Value;
}