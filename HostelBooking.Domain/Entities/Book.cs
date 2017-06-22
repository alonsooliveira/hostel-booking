using System;
using System.Collections.Generic;

namespace HostelBooking.Domain.Entities
{
    public class Book
    {
        public Room Room { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
