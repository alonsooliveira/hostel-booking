using HostelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelBooking.Domain.AppService
{
    public interface IRoomAppService
    {
        IEnumerable<Room> GetAll();
        void Save(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
