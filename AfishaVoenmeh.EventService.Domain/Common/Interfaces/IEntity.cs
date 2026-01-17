namespace AfishaVoenmeh.EventService.Domain.Common.Interfaces;

public interface IEntity<TId>
{
    TId Id { get; }
}
