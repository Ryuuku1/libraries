using Domain.Entities;

namespace Libraries.Tests.Features.Domain.Specifications;

internal sealed class TestEntity : Entity
{
    public string Name { get; set; } = string.Empty;
}
