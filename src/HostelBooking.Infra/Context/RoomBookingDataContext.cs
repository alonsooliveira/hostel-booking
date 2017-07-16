using HostelBooking.Domain.Entities;
using System.Data.Entity;
using System.Data;
using HostelBooking.Infra.Mappings;

namespace HostelBooking.Infra.Context
{
    public class RoomBookingDataContext : DbContext
    {
        public RoomBookingDataContext() : base(@"Server=localhost;Database=HostelBooking;User Id=SA; Password=sys@36911;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Room> Rooms { get; set; }
        //public DbSet<Guest> Guests { get; set; }
        //public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new RoomMap());
        }
    }
}
