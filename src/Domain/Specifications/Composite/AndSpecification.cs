using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Specifications.Composite;

/// <summary>
/// Represents an and specification for filtering entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public class AndSpecification<T> : Specification<T>
    where T : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AndSpecification{T}"/> class with the specified left and right specifications.
    /// </summary>
    /// <param name="left">The left specification.</param>
    /// <param name="right">The right specification.</param>
    public AndSpecification(Specification<T> left, Specification<T> right)
        : base(Combine(left, right)) { }

    private static Expression<Func<T, bool>> Combine(Specification<T> left, Specification<T> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(
            Expression.Invoke(left.Criteria, parameter),
            Expression.Invoke(right.Criteria, parameter)
        );
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}
