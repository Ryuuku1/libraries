namespace Libraries.Tests.Features.Domain.Specifications;

public class SpecificationTests
{
    [Fact]
    public void Specification_WhenIsSatisfied_ReturnsTrue()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.Empty };
        var sut = new TestSpecificationId(x => x.Id == Guid.Empty);

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_ReturnsFalse()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.NewGuid() };
        var sut = new TestSpecificationId(x => x.Id == Guid.Empty);

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeFalse();
    }
}
