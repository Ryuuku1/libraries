using Domain.Entities;

namespace Domain.Repositories.Queries;

/// <summary>
/// Represents a contract for listing entities.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IListEntity<out T>
    where T : Entity
{
    /// <summary>
    /// Lists entities asynchronously based on the specified ID.
    /// </summary>
    /// <param name="id">The ID to filter the entities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An asynchronous enumerable of entities.</returns>
    IQueryable<T> ListAsync(CancellationToken cancellationToken = default);
}
