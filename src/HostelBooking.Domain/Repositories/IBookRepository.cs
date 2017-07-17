using HostelBooking.Domain.Entities;
using System.Collections.Generic;

namespace HostelBooking.Domain.Repositories
{
    public interface IBookRepository
    {
        void Save(Book book);
        void Update(Book book);
        IEnumerable<Book> GetAllBookByGuest(int idGuest);
        Book GetBookByGuest(int idGuest);
    }
}
