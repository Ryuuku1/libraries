using System.Diagnostics.CodeAnalysis;

namespace Results;

/// <summary>
/// Represents the result of an operation.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation was successful.</param>
    /// <param name="error">The error associated with the result.</param>
    protected Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the error associated with the result.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>The successful result.</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Creates a successful result with the specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value associated with the success.</param>
    /// <returns>The successful result with the specified value.</returns>
    public static Result<T> Success<T>(T value) => new(value, true, Error.None);

    /// <summary>
    /// Creates a failure result with the specified error message.
    /// </summary>
    /// <param name="errorMessage">The error message associated with the failure.</param>
    /// <param name="title">The error title associated with the failure.</param>
    /// <returns>The failure result.</returns>
    public static Result Failure(string errorMessage = "An error occurred.", string title = "Error")
    {
        var error = new Error(errorMessage, title);
        return new(false, error);
    }

    /// <summary>
    /// Creates a failure result with the specified error.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="errorMessage">The error message associated with the failure.</param>
    /// <param name="title">The error title associated with the failure.</param>
    /// <returns>The failure result with the specified error.</returns>
    public static Result<T> Failure<T>(
        string errorMessage = "An error occurred.",
        string title = "Error"
    )
    {
        var error = new Error(errorMessage, title);
        return new(default, false, error);
    }

    /// <summary>
    /// Creates a result with the specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value associated with the result.</param>
    /// <returns>The result with the specified value.</returns>
    public static Result<T> Create<T>(T? value) =>
        value is not null ? Success(value) : Failure<T>(Error.NullValue);

    /// <summary>
    /// Creates a failure result with the specified error.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="error">The error associated with the failure.</param>
    /// <returns>The failure result with the specified error.</returns>
    public static Result<T> Failure<T>(Error error) => new(default, false, error);
}

/// <summary>
/// Represents the result of an operation with a value.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public sealed class Result<T> : Result
{
    private readonly T? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class.
    /// </summary>
    /// <param name="value">The value associated with the result.</param>
    /// <param name="isSuccess">Indicates whether the operation was successful.</param>
    /// <param name="error">The error associated with the result.</param>
    public Result(T? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    /// <summary>
    /// Gets the value associated with the successful result.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when trying to access the value of a failure result.</exception>
    [NotNull]
    public T Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException(
                "The value of a failure result cannot be accessed."
            );

    /// <summary>
    /// Implicitly converts a value to a result.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The result with the specified value.</returns>
    public static implicit operator Result<T>(T? value) => Create(value);
}
