using Domain.Entities;

namespace Domain.Repositories.Commands;

/// <summary>
/// Represents an interface for updating an entity.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IUpdateEntity<in T>
    where T : Entity
{
    /// <summary>
    /// Updates the specified entity asynchronously.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task<Entity> UpdateAsync(T entity, CancellationToken cancellationToken = default);
}
