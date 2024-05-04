namespace Libraries.Features.Entities;

/// <summary>
/// Represents an entity in the system.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    protected Entity(Guid id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    protected Entity() { }

    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; init; }
}
