namespace Libraries.Features.Results;

/// <summary>
/// Represents an error with a message.
/// </summary>
public record Error(string Message, string Title)
{
    /// <summary>
    /// Represents an empty error.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// Represents an error indicating that a null value was provided.
    /// </summary>
    public static readonly Error NullValue = new("Null value was provided.", "Null value.");
}
