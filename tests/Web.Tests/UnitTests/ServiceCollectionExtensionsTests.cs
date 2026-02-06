using Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Tests.UnitTests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddSharedServices_ReturnsServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        var result = services.AddSharedServices();

        // Assert
        Assert.Same(services, result);
    }
}
