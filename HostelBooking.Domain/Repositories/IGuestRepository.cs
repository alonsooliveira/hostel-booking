using HostelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelBooking.Domain.Repositories
{
    public interface IGuestRepository
    {
        Guest Get(int id);
        void Save(Guest guest);
        void Update(Guest guest);
    }
}
