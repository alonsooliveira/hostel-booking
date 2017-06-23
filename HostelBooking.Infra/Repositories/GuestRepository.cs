using HostelBooking.Domain.Repositories;
using System.Linq;
using HostelBooking.Domain.Entities;
using HostelBooking.Infra.Context;
using System.Data.Entity;

namespace HostelBooking.Infra.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HostelBookingDataContext _context;

        public GuestRepository(HostelBookingDataContext context)
        {
            _context = context;
        }

        public Guest Get(int id) => _context.Guests.FirstOrDefault(x => x.Id == id);
       
        public void Save(Guest guest) => _context.Entry(guest).State = EntityState.Added;
        
        public void Update(Guest guest) => _context.Entry(guest).State = EntityState.Modified;   
    }
}
