using Bunit;
using Web.Components.Pages;

namespace Web.Tests.ComponentTests;

public class HomeTests : TestContext
{
    [Fact]
    public void Home_RendersHelloText()
    {
        // Act
        var cut = RenderComponent<Home>();

        // Assert
        cut.MarkupMatches(
            """
            <div class="flex min-h-screen items-center justify-center bg-zinc-50 font-sans dark:bg-black">
                Hello
            </div>
            """);
    }
}
