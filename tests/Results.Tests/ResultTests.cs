using Results;

namespace Libraries.Tests.Features.Results;

public class ResultTests
{
    [Fact]
    public void Success_ShouldCreateSuccessfulResult()
    {
        // Act
        var result = Result.Success();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void SuccessWithValue_ShouldCreateSuccessfulResultWithValue()
    {
        // Arrange
        var value = "Test";

        // Act
        var result = Result.Success(value);

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeTrue();
            result.Error.Should().Be(Error.None);
            result.Value.Should().Be(value);
        }
    }

    [Fact]
    public void Failure_ShouldCreateFailureResultWithDefaultErrorMessageAndTitle()
    {
        // Act
        var result = Result.Failure();

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeFalse();
            result.Error.Message.Should().Be("An error occurred.");
            result.Error.Title.Should().Be("Error");
        }
    }

    [Fact]
    public void FailureWithValue_ShouldCreateFailureResultWithValueAndDefaultErrorMessageAndTitle()
    {
        // Act
        var result = Result.Failure<string>();
        var getValue = () => result.Value;

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeFalse();
            result.Error.Message.Should().Be("An error occurred.");
            result.Error.Title.Should().Be("Error");
            getValue.Should().Throw<InvalidOperationException>();
        }
    }

    [Fact]
    public void Create_ShouldCreateResultWithNonNullValue()
    {
        // Arrange
        var value = "Test";

        // Act
        var result = Result.Create(value);

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeTrue();
            result.Error.Should().Be(Error.None);
            result.Value.Should().Be(value);
        }
    }

    [Fact]
    public void Create_ShouldCreateFailureResultWithNullValue()
    {
        // Act
        var result = Result.Create<string>(null);
        var getValue = () => result.Value;

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeFalse();
            result.Error.Message.Should().Be(Error.NullValue.Message);
            result.Error.Title.Should().Be(Error.NullValue.Title);
            getValue.Should().Throw<InvalidOperationException>();
        }
    }

    [Fact]
    public void Create_WithNullValue_ReturnsFailureResult()
    {
        // Arrange
        int? value = null;

        // Act
        var result = Result.Create(value);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(Error.NullValue);
    }

    [Fact]
    public void Failure_ShouldCreateFailureResultWithNullValue()
    {
        // Arrange
        var error = Error.NullValue;

        // Act
        var result = Result.Failure<int>(error);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(Error.NullValue);
    }

    [Fact]
    public void Operator_ShouldCreateResultWithNonNullValue()
    {
        // Arrange
        var value = "Test";

        // Act
        Result<string> result = value;

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeTrue();
            result.Error.Should().Be(Error.None);
            result.Value.Should().Be(value);
        }
    }

    [Fact]
    public void Operator_ShouldCreateFailureResultWithNullValue()
    {
        // Act
        Result<string> result = (string)null!;
        var getValue = () => result.Value;

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeFalse();
            result.Error.Message.Should().Be(Error.NullValue.Message);
            result.Error.Title.Should().Be(Error.NullValue.Title);
            getValue.Should().Throw<InvalidOperationException>();
        }
    }
}
