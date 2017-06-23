using HostelBooking.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HostelBooking.Infra.Mappings
{
    public class GuestMap : EntityTypeConfiguration<Guest>
    {
        public GuestMap()
        {
            ToTable("Guest");
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.Document);
            Property(x => x.Genre);
            Property(x => x.BirthDate);
            Property(x => x.Email);
            Property(x => x.Password);
        }
    }
}
