using Domain.Entities;
using Domain.Specifications;

namespace Domain.Repositories.Queries;

/// <summary>
/// Represents a contract for finding entities asynchronously.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IFindEntity<T>
    where T : Entity
{
    /// <summary>
    /// Finds entities asynchronously based on the specified specification.
    /// </summary>
    /// <param name="specification">The specification to filter the entities.</param>
    /// <param name="keepTracking">Indicated if the entity is to keep track on EF.</param>
    /// <returns>An asynchronous enumerable of entities.</returns>
    IQueryable<T> FindAsync(Specification<T> specification, bool keepTracking = false);

    /// <summary>
    /// Finds entities asynchronously based on the specified specification.
    /// </summary>
    /// <param name="specification">The specification to filter the entities.</param>
    /// <param name="keepTracking">Indicated if the entity is to keep track on EF.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An asynchronous enumerable of entities.</returns>
    Task<IEnumerable<T>> FindAsync(
        Specification<T> specification,
        CancellationToken cancellationToken = default,
        bool keepTracking = false
    );
}
