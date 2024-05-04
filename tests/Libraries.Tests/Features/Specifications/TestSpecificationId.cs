using System.Linq.Expressions;
using Libraries.Features.Specification;

namespace Libraries.Tests.Features.Specifications;

internal class TestSpecificationId : Specification<TestEntity>
{
    public TestSpecificationId(Expression<Func<TestEntity, bool>> criteria)
        : base(criteria) { }
}
