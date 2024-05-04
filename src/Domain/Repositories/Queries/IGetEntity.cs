using Domain.Entities;

namespace Domain.Repositories.Queries;

/// <summary>
/// Represents an interface for getting an entity by its ID.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IGetEntity<T>
    where T : Entity
{
    /// <summary>
    /// Gets an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The entity if found, otherwise null.</returns>
    Task<T> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default,
        bool withTracking = false
    );
}
