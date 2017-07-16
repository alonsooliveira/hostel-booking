using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelBooking.Domain.Repositories.Transaction;
using HostelBooking.Domain.AppService;
using HostelBooking.Domain.Entities;
using HostelBooking.Domain.Repositories;

namespace HostelBooking.ApplicationService.AppService
{
    public class GuestAppService : BaseService, IGuestAppService
    {
        private readonly IGuestRepository _repository;

        public GuestAppService(IGuestRepository repository, IUoW uow) : base(uow)
        {
            _repository = repository;
        }

        public Guest Get(int id)
        {
            return _repository.Get(id);
        }

        public Guest GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public void Save(Guest guest)
        {
            _repository.Save(guest);
            Commit();
        }

        public void Update(Guest guest)
        {
            _repository.Update(guest);
        }
    }
}
