namespace Pagination.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when invalid data is encountered in a paged request.
    /// </summary>
    public class InvalidPagedRequestDataException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPagedRequestDataException"/> class with a default error message.
        /// </summary>
        public InvalidPagedRequestDataException()
            : base("Invalid pagination parameters.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPagedRequestDataException"/> class with a specified error message.
        /// </summary>
        /// <param name="errors">The error messages that explains the reason for the exception.</param>
        public InvalidPagedRequestDataException(IEnumerable<string> errors)
            : base($"Invalid pagination parameters: {string.Join(", ", errors)}.") { }
    }
}
