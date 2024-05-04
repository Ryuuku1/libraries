namespace Libraries.Tests.Features.Specifications;

public class OrSpecificationTests
{
    [Fact]
    public void Specification_WhenIsSatisfied_ReturnsTrue()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.Empty, Name = "Name" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            | new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_JustForLeftCondition_ReturnsTrue()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Name" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            | new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_JustForRightCondition_ReturnsTrue()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.Empty, Name = "" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            | new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_ForBothConditions_ReturnsFalse()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            | new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeFalse();
    }
}
