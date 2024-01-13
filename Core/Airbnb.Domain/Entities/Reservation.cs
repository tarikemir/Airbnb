using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int reservation_id { get; set; }
        public int renter_id { get; set; }
        public DateTime end_date { get; set; }
        public DateTime start_date { get; set; }
        public int room_id { get; set; }
        public DateTime updated_at { get; set; }
        public int total { get; set; }
        public int unit_price { get; set; }
        public int owner_id { get; set; }
    }
}
