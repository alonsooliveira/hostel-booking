using HostelBooking.Domain.Entities;
using System.Collections.Generic;

namespace HostelBooking.Domain.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room Get(int id);
        void Save(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
