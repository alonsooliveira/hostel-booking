using HostelBooking.Domain.Base;
using HostelBooking.Domain.Entities;
using HostelBooking.Infra.Mappings;
using System.Data.Entity;

namespace HostelBooking.Infra.Context
{
    public class HostelBookingDataContext : DbContext
    {
        public HostelBookingDataContext() : base(Settings.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        //public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new GuestMap());
        }
    }
}
