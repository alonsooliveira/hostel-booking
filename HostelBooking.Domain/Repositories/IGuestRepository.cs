using HostelBooking.Domain.Entities;

namespace HostelBooking.Domain.Repositories
{
    public interface IGuestRepository
    {
        Guest GetByEmail(string email);
        Guest Get(int id);
        void Save(Guest guest);
        void Update(Guest guest);
    }
}
