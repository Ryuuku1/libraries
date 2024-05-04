using Results;

namespace Libraries.Tests.Features.Results;

public class ErrorTests
{
    [Fact]
    public void None_ShouldHaveEmptyMessageAndTitle()
    {
        // Arrange
        var error = Error.None;

        // Assert
        error.Message.Should().BeEmpty();
        error.Title.Should().BeEmpty();
    }

    [Fact]
    public void NullValue_ShouldHaveSpecificMessageAndTitle()
    {
        // Arrange
        var error = Error.NullValue;

        // Assert
        error.Message.Should().Be("Null value was provided.");
        error.Title.Should().Be("Null value.");
    }
}
