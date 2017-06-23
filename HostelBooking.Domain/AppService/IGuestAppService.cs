using HostelBooking.Domain.Entities;
using System.Collections.Generic;

namespace HostelBooking.Domain.AppService
{
    public interface IGuestAppService
    {        
        Guest Get(int id);
        void Save(Guest guest);
        void Update(Guest guest);
    }
}
