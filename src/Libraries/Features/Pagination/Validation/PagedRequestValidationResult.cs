namespace Libraries.Features.Pagination.Validation
{
    /// <summary>
    /// Represents the result of validating a paged request, indicating whether it is valid or not.
    /// </summary>
    public sealed class PagedRequestValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedRequestValidationResult"/> class.
        /// </summary>
        /// <param name="isValid">A boolean indicating whether the paged request is valid.</param>
        /// <param name="errors">The error messages describing the validation failure, if any. Null if the request is valid.</param>
        private PagedRequestValidationResult(bool isValid, IEnumerable<string> errors)
        {
            IsValid = isValid;
            Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether the paged request is valid.
        /// </summary>
        public bool IsValid { get; init; }

        /// <summary>
        /// Gets the error messages describing the validation failure, if any. Null if the request is valid.
        /// </summary>
        public IEnumerable<string> Errors { get; init; }

        /// <summary>
        /// Creates a new instance of <see cref="PagedRequestValidationResult"/> with the specified validity and error message.
        /// </summary>
        /// <param name="isValid">A boolean indicating whether the paged request is valid.</param>
        /// <param name="errors">The error messages describing the validation failure, if any. Null if the request is valid.</param>
        /// <returns>A new instance of <see cref="PagedRequestValidationResult"/>.</returns>
        public static PagedRequestValidationResult Create(
            bool isValid,
            IEnumerable<string> errors = null
        )
        {
            return new PagedRequestValidationResult(isValid, errors);
        }
    }
}
