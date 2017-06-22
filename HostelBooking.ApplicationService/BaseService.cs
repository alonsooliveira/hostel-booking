using HostelBooking.Domain.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelBooking.ApplicationService
{
    public class BaseService
    {
        private IUoW _uow;

        public BaseService(IUoW uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
