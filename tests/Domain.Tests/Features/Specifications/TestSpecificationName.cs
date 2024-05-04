using System.Linq.Expressions;
using Domain.Specifications;

namespace Libraries.Tests.Features.Domain.Specifications;

internal class TestSpecificationName : Specification<TestEntity>
{
    public TestSpecificationName(Expression<Func<TestEntity, bool>> criteria)
        : base(criteria) { }
}
