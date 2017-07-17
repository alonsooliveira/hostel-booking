using HostelBooking.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HostelBooking.Infra.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");

            HasKey(x => x.Id);

            HasRequired(x => x.Room)
               .WithMany()
               .Map(m => m.MapKey("RoomId"));

            HasRequired(x => x.Guest)
                .WithMany()
                .Map(m => m.MapKey("GuestId"));

            Property(x => x.startDate)
                .IsRequired();

            Property(x => x.endDate)
                .IsRequired();

            Property(x => x.Active)
                .IsRequired();
        }
    }
}
