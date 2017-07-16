using HostelBooking.Domain.AppService;
using HostelBooking.Domain.Entities;
using HostelBooking.Domain.Repositories;
using HostelBooking.Domain.Repositories.Transaction;
using System.Collections.Generic;

namespace HostelBooking.ApplicationService.AppService
{
    public class RoomAppService : BaseService, IRoomAppService
    {
        private readonly IRoomRepository _repository;

        public RoomAppService(IRoomRepository repository, IUoW uow) : base(uow)
        {
            _repository = repository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll();
        }

        public void Save(Room room)
        {
            _repository.Save(room);
            Commit();
        }

        public void Update(Room room)
        {
            _repository.Update(room);
            Commit();
        }

        public void Delete(Room room)
        {
            _repository.Delete(room);
            Commit();
        }
    }
}
