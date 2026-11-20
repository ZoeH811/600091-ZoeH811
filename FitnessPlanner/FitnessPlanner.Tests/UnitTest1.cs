using Xunit;

namespace FitnessPlanner.Tests;

public class InitialTests
{
    [Fact]
    public void TestFramework_ShouldRunSuccessfully()
    {
        // Arrange
        int expected = 10;

        // Act
        int actual = 5 + 5;

        // Assert
        Assert.Equal(expected, actual);
    }
}
