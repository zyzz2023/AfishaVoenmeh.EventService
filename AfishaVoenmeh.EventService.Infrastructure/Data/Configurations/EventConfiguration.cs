using AfishaVoenmeh.EventService.Domain.EventAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AfishaVoenmeh.EventService.Infrastructure.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.Period, ba =>
        {
            ba.Property(p => p.StartsAt)
                .HasColumnName("StartsAt")
                .HasColumnType("timestamp with time zone");

            ba.Property(p => p.EndsAt)
                .HasColumnName("EndsAt")
                .HasColumnType("timestamp with time zone");
        });

        builder.OwnsOne(e => e.SeatsNumber, ba =>
        {
            ba.Property(sn => sn.Total)
                .HasColumnName("TotalSeats");

            ba.Property(sn => sn.Current)
                .HasColumnName("CurrentSeats");
        });

        builder.OwnsOne(e => e.ImageUrl, ba =>
        {
            ba.Property(iu => iu.Value)
                .HasColumnName("ImageUrl");
        });

        builder.OwnsOne(e => e.Location, ba =>
        {
            ba.Property(l => l.City)
                .HasColumnName("City")
                .IsRequired()
                .HasMaxLength(50);

            ba.Property(l => l.Street)
                .HasColumnName("Street")
                .IsRequired()
                .HasMaxLength(80);

            ba.Property(l => l.Number)
                .HasColumnName("Number");
        });

        builder.Property(e => e.Status) 
            .HasColumnName("Status")
            .IsRequired();

        builder.Property(e => e.Target)
            .HasColumnName("Target")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}