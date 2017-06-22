using HostelBooking.Domain.Base;

namespace HostelBooking.Domain.Entities
{
    public class Room : Entity
    {
        public int RoomNumber { get; set; }
        public int TotalBed { get; set; }
    }
}
