using Domain.Entities;

namespace Libraries.Tests.Features.Domain.Entities;

public class EntityTests
{
    [Fact]
    public void CreateEntity_WithId_ShouldSetId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var entity = new TestEntity(id);

        // Assert
        entity.Id.Should().Be(id);
    }

    [Fact]
    public void CreateEntity_WithoutId_ShouldNotGenerateId()
    {
        // Act
        var entity = new TestEntity();

        // Assert
        entity.Id.Should().BeEmpty();
    }

    private class TestEntity : Entity
    {
        public TestEntity(Guid id)
            : base(id) { }

        public TestEntity() { }
    }
}
