namespace Pagination.Abstractions
{
    /// <summary>
    /// Represents an abstract class for paginated requests.
    /// </summary>
    public abstract class PagedRequest
    {
        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int PageIndex { get; init; }

        /// <summary>
        /// Gets the number of items per page.
        /// </summary>
        public int PageSize { get; init; }
    }
}
