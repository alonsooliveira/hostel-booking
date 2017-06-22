using HostelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelBooking.Infra.Mappings
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            ToTable("Room");
            HasKey(x => x.Id);
            Property(x => x.RoomNumber);
            Property(x => x.TotalBed);
        }
    }
}
