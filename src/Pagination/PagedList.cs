using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pagination.Exceptions;
using Pagination.Validation;

namespace Pagination
{
    /// <summary>
    /// Represents a paginated list of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    [JsonObject]
    public class PagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="items">The collection of items in the current page.</param>
        /// <param name="pageIndex">The current page number.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="totalCount">The total number of items across all pages.</param>
        [JsonConstructor]
        private PagedList(List<T> items, int pageIndex, int pageSize, int totalCount)
        {
            Items = items;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Gets the collection of items in the current page.
        /// </summary>
        [JsonProperty("items")]
        public List<T> Items { get; }

        /// <summary>
        /// Gets the current page number.
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; }

        /// <summary>
        /// Gets the size of each page.
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; }

        /// <summary>
        /// Gets the total number of items across all pages.
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; }

        /// <summary>
        /// Creates an instance of <see cref="PagedList{T}"/> asynchronously based on the provided query.
        /// </summary>
        /// <param name="query">The queryable collection of items.</param>
        /// <param name="pageIndex">The page number to retrieve.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <returns>An asynchronous task that represents the creation of the paginated list.</returns>
        public static async Task<PagedList<T>> CreateAsync(
            IQueryable<T> query,
            int pageIndex,
            int pageSize
        )
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            var count = await query.CountAsync();
            var items = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            return new(items, pageIndex, pageSize, count);
        }

        /// <summary>
        /// Creates an instance of <see cref="PagedList{T}"/> from the provided collection.
        /// </summary>
        /// <param name="collection">The source collection to be paginated.</param>
        /// <param name="pageIndex">The index of the requested page (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A paged list containing the items for the specified page.</returns>
        public static PagedList<T> Create(IEnumerable<T> collection, int pageIndex, int pageSize)
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            var items = collection.ToList();

            var pageItems = items.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new(pageItems, pageIndex, pageSize, items.Count);
        }

        /// <summary>
        /// Creates an instance of <see cref="PagedList{T}"/> from the provided collection, allowing sorting.
        /// </summary>
        /// <typeparam name="TKey">The type of the key used for sorting.</typeparam>
        /// <param name="collection">The source collection to be paginated and optionally sorted.</param>
        /// <param name="pageIndex">The index of the requested page (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="sortBy">The function to extract the key for sorting.</param>
        /// <param name="isDescending">Specifies whether to sort the items in descending order (default is ascending).</param>
        /// <returns>A paged list containing the items for the specified page.</returns>

        public static PagedList<T> Create<TKey>(
            IEnumerable<T> collection,
            int pageIndex,
            int pageSize,
            Func<T, TKey> sortBy,
            bool isDescending = false
        )
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            var items = OrderCollection(collection, sortBy, isDescending).ToList();

            var pageItems = items.Skip(pageIndex * pageSize).Take(pageSize);

            return new(pageItems.ToList(), pageIndex, pageSize, items.Count);
        }

        private static void ValidatePaginationParameters(int pageIndex, int pageSize)
        {
            var errors = GetErrors(pageIndex, pageSize).ToList();
            var validationResult = PagedRequestValidationResult.Create(!errors.Any(), errors);

            if (!validationResult.IsValid)
            {
                throw new InvalidPagedRequestDataException(validationResult.Errors);
            }
        }

        private static IEnumerable<string> GetErrors(int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
            {
                yield return ValidationErrors.PageIndexMustBeANonNegativeValue;
            }

            if (pageSize < 0)
            {
                yield return ValidationErrors.PageSizeMustBeANonNegativeValue;
            }
        }

        private static IEnumerable<T> OrderCollection<TKey>(
            IEnumerable<T> collection,
            Func<T, TKey> sortBy,
            bool isDescending
        )
        {
            return isDescending ? collection.OrderByDescending(sortBy) : collection.OrderBy(sortBy);
        }
    }
}