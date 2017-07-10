using HostelBooking.Domain.Repositories.Transaction;

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
