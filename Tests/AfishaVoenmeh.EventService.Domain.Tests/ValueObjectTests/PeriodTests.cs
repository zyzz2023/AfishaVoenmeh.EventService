using AfishaVoenmeh.EventService.Domain.Common.Errors;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

namespace AfishaVoenmeh.EventService.Domain.Tests.ValueObjectTests;

public class PeriodTests
{
    [Fact]
    public void Create_CreatePeriod_ReturnNoErrors()
    {
        // Arrange
        var startsAt = DateTime.UtcNow.AddHours(1);
        var endsAt = startsAt.AddHours(6);

        // Act
        var period = Period.Create(startsAt, endsAt);

        // Assert
        Assert.False(period.IsError);
        Assert.NotNull(period.Value);
        Assert.Equal(period.Value.StartsAt, startsAt);
        Assert.Equal(period.Value.EndsAt, endsAt);
    }

    [Theory]
    [InlineData(0)] // start equals end
    [InlineData(-1)] // start after end
    public void Create_Should_ReturnInvalidPeriodError(int hours)
    {
        // Arrange
        var startsAt = DateTime.UtcNow.AddHours(1);
        var endsAt = startsAt.AddHours(hours);

        // Act
        var period = Period.Create(startsAt, endsAt);

        // Assert
        Assert.True(period.IsError);
    }

    [Fact]
    public void Create_Should_ReturnLongPeriodError()
    {
        // Arrange
        var startsAt = DateTime.UtcNow.AddHours(1);
        var endsAt = startsAt.AddHours(9);

        // Act
        var period = Period.Create(startsAt, endsAt);

        // Assert
        Assert.True(period.IsError);
        Assert.Equal(period.FirstError, DomainErrors.LongPeriod);
    }
}