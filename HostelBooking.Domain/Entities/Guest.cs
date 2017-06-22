using HostelBooking.Domain.Base;
using System;

namespace HostelBooking.Domain.Entities
{
    public class Guest : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime Birth { get; set; }
        public int Genre { get; set; }
    }
}
