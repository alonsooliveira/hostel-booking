using HostelBooking.Domain.Base;
using System;

namespace HostelBooking.Domain.Entities
{
    public class Guest : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public int Genre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
