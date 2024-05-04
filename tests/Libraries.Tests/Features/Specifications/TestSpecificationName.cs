using System.Linq.Expressions;
using Libraries.Features.Specification;

namespace Libraries.Tests.Features.Specifications;

internal class TestSpecificationName : Specification<TestEntity>
{
    public TestSpecificationName(Expression<Func<TestEntity, bool>> criteria)
        : base(criteria) { }
}
