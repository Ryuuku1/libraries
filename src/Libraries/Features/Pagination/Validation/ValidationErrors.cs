namespace Libraries.Features.Pagination.Validation
{
    /// <summary>
    /// Contains constant strings representing validation error messages for pagination parameters.
    /// </summary>
    internal static class ValidationErrors
    {
        /// <summary>
        /// Error message for the case when the page value is a negative number.
        /// </summary>
        internal const string PageIndexMustBeANonNegativeValue =
            "Page index must be a non-negative value.";

        /// <summary>
        /// Error message for the case when the PageSize value is a negative number.
        /// </summary>
        internal const string PageSizeMustBeANonNegativeValue =
            "PageSize must be a non-negative value.";
    }
}
