using HostelBooking.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HostelBooking.Infra.Mappings
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            ToTable("Room");

            HasKey(x => x.Id);

            Property(x => x.RoomNumber)
                .IsRequired();

            Property(x => x.TotalBed)
                .IsRequired();

            Property(x => x.Description)
               .HasColumnType("VARCHAR")
               .HasMaxLength(250)
               .IsRequired();
        }
    }
}
