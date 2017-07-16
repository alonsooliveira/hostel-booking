using HostelBooking.Domain.Repositories.Transaction;
using HostelBooking.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelBooking.Infra.Transaction
{
    public class UoW : IUoW
    {
        private readonly HostelBookingDataContext _context;

        public UoW(HostelBookingDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
