using System.Linq.Expressions;
using Libraries.Features.Entities;
using Libraries.Features.Specification.Composite;

namespace Libraries.Features.Specification;

/// <summary>
/// Represents a specification for filtering entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public abstract class Specification<T>
    where T : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Specification{T}"/> class with the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria expression.</param>
    protected Specification(Expression<Func<T, bool>> criteria)
    {
        this.Criteria = criteria;
    }

    /// <summary>
    /// Gets the criteria expression.
    /// </summary>
    public Expression<Func<T, bool>> Criteria { get; }

    public static Specification<T> operator &(Specification<T> left, Specification<T> right)
    {
        return new AndSpecification<T>(left, right);
    }

    public static Specification<T> operator |(Specification<T> left, Specification<T> right)
    {
        return new OrSpecification<T>(left, right);
    }
}
