using HostelBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelBooking.Domain.Entities;
using HostelBooking.Infra.Context;
using System.Data.Entity;

namespace HostelBooking.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly HostelBookingDataContext _context;

        public BookRepository(HostelBookingDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBookByGuest(int idGuest)
        {
            throw new NotImplementedException();
        }

        public Book GetBookByGuest(int idGuest)
        {
            throw new NotImplementedException();
        }

        public void Save(Book book)
        {
            _context.Entry(book).State = EntityState.Added;
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }
    }
}
