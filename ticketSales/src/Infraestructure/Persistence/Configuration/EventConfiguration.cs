using Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configuration;

public class EventConfiguration : IEntityTypeConfiguration<Event>
 {   public void Configure(EntityTypeBuilder<Event> builder)
    {

        builder.ToTable("Eventos");

        builder.HasKey(c=> c.Id);
        builder.Property(c=>c.Id).HasConversion(
            eventId => eventId.Value,
            value => new EventId(value));
        builder.Property(c=> c.EventDate).HasMaxLength(50);

       builder.OwnsOne(c=> c.EventLocation, addressBuilder => {
            addressBuilder.Property(a=> a.Country).HasMaxLength(3);
            addressBuilder.Property(a=> a.Line1).HasMaxLength(20);
            addressBuilder.Property(a=> a.Line2).HasMaxLength(20).IsRequired(false);
            addressBuilder.Property(a=> a.City).HasMaxLength(20);
            addressBuilder.Property(a=> a.State).HasMaxLength(20);
            addressBuilder.Property(a=> a.ZipCode).HasMaxLength(10).IsRequired(false);
       });
       builder.Property(c=> c.EventCost).HasMaxLength(20);
       builder.Property(c=> c.EventActive).HasMaxLength(1).IsRequired(false);

    }
}
