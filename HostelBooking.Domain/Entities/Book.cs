using HostelBooking.Domain.Base;
using System;
using System.Collections.ObjectModel;

namespace HostelBooking.Domain.Entities
{
    public class Book : Entity
    {
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool Active { get; set; }
    }
}
