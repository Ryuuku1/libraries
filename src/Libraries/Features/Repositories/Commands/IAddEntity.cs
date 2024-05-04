using Libraries.Features.Entities;

namespace Libraries.Features.Repositories.Commands;

/// <summary>
/// Represents an interface for adding an entity to a repository.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IAddEntity<in T>
    where T : Entity
{
    /// <summary>
    /// Adds an entity to the repository asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the add operation.</returns>
    Task<Entity> AddAsync(T entity, CancellationToken cancellationToken = default);
}
