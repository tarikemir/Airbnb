using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Entities
{
    public class Room
    {
        [Key]
        public int room_id { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public int price { get; set; }
        public string summary { get; set; }
        public string address { get; set; }
        public string home_type { get; set; }
        public string room_type { get; set; }
        public bool status { get; set; }
        public int total_bedrooms { get; set; }
        public int total_bathrooms { get; set; }
        public int admin_id { get; set; }
        public bool admin_verification { get; set; }
        public float longitude { get; set; }
        public bool has_heating { get; set; }
        public float latitude { get; set; }
        public bool has_tv { get; set; }
        public bool has_internet { get; set; }
        public bool has_air_con { get; set; }
        public int owner_id { get; set; }
    }
}
