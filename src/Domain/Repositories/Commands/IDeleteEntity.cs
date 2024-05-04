using Domain.Entities;

namespace Domain.Repositories.Commands;

/// <summary>
/// Represents an interface for deleting an entity.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IDeleteEntity<in T>
    where T : Entity
{
    /// <summary>
    /// Deletes the specified entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
