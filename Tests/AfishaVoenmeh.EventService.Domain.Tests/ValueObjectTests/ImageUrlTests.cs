using AfishaVoenmeh.EventService.Domain.Common.Errors;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

namespace AfishaVoenmeh.EventService.Domain.Tests.ValueObjectTests;

public class ImageUrlTests
{
    [Fact]
    public void Create_Should_ReturnSuccessUrl()
    {
        // Arrange
        string url = "https://6ef4e6a1-9d49-47ac-bfed-170f67a815cf.selcdn.net/blog/wp-content/uploads/2026/01/MD-6070_yellow-1.png";

        // Act
        var imageUrl = ImageUrl.Create(url);

        // Assert
        Assert.False(imageUrl.IsError);
        Assert.NotNull(imageUrl.Value);
        Assert.Equal(imageUrl.Value.Value, url);
    }

    [Fact]
    public void Create_Should_ReturnBadUrlError()
    {
        // Arrange
        string url = "https//6ef4e6a1-9d49-47ac-bfed-170f67a815cf.selcdn.net/blog/wp-content/uploads/2026/01/MD-6070_yellow-1png";

        // Act
        var imageUrl = ImageUrl.Create(url);

        // Assert
        Assert.True(imageUrl.IsError);
        Assert.Equal(imageUrl.FirstError, DomainErrors.BadUrl);
    }
}