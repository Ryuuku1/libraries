namespace Libraries.Tests.Features.Domain.Specifications;

public class AndSpecificationTests
{
    [Fact]
    public void Specification_WhenIsSatisfied_ReturnsTrue()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.Empty, Name = "Name" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            & new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_ForLeftCondition_ReturnsFalse()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Name" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            & new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_ForRightCondition_ReturnsFalse()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.Empty, Name = "" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            & new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Specification_WhenIsNotSatisfied_ForBothConditions_ReturnsFalse()
    {
        // Arrange
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "" };
        var sut =
            new TestSpecificationId(x => x.Id == Guid.Empty)
            & new TestSpecificationName(x => !string.IsNullOrEmpty(x.Name));

        // Act
        var result = sut.Criteria.Compile().Invoke(entity);

        // Assert
        result.Should().BeFalse();
    }
}
