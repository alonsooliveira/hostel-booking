using HostelBooking.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace HostelBooking.Infra.Mappings
{
    public class GuestMap : EntityTypeConfiguration<Guest>
    {
        public GuestMap()
        {
            ToTable("Guest");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Document)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            Property(x => x.Genre);

            Property(x => x.BirthDate);

            Property(x => x.User.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(160)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.User.Password)
                .HasColumnName("Password")
                .HasColumnType("VARCHAR")
                .HasMaxLength(32)
                .IsFixedLength(); ;

            Property(x => x.User.Active)
                .HasColumnName("Active");
        }
    }
}
