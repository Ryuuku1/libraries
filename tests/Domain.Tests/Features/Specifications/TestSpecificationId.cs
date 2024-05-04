using System.Linq.Expressions;
using Domain.Specifications;

namespace Libraries.Tests.Features.Domain.Specifications;

internal class TestSpecificationId : Specification<TestEntity>
{
    public TestSpecificationId(Expression<Func<TestEntity, bool>> criteria)
        : base(criteria) { }
}
