using HostelBooking.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using HostelBooking.Domain.Entities;
using HostelBooking.Infra.Context;
using System.Data.Entity;

namespace HostelBooking.Infra.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HostelBookingDataContext _context;

        public RoomRepository(HostelBookingDataContext context)
        {
            _context = context;
        }

        public Room Get(int id) => 
            _context.Rooms.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Room> GetAll() =>
            _context.Rooms.AsNoTracking().ToList();
        
        public void Save(Room room) => 
            _context.Entry(room).State = EntityState.Added;

        public void Update(Room room) => 
            _context.Entry(room).State = EntityState.Modified;

        public void Delete(Room room) => 
            _context.Entry(room).State = EntityState.Deleted;

    }
}
