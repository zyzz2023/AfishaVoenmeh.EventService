using AfishaVoenmeh.EventService.Domain.Common.Interfaces;
using System;
namespace AfishaVoenmeh.EventService.Domain.Common.Abstract;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IEntity<TId>
    where TId : notnull
{
    public TId Id { get; protected set; }

    protected Entity() { } // EF Core

    protected Entity(TId id) => Id = id;

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }
    public bool Equals(Entity<TId>? other) => Equals((object?)other);

    public override int GetHashCode() => Id.GetHashCode();
}
