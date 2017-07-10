using HostelBooking.Domain.Repositories;
using System.Linq;
using HostelBooking.Domain.Entities;
using HostelBooking.Infra.Context;
using System.Data.Entity;
using System;

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

        public Guest GetByEmail(string email) => _context.Guests.FirstOrDefault(x => x.User.Email == email);

        public void Save(Guest guest) => _context.Guests.Add(guest);
           
        public void Update(Guest guest) => _context.Entry(guest).State = EntityState.Modified;   
    }
}
