using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Entities
{
    public class Renter
    {
        [Key]
        public int renter_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string remember_token { get; set; }
        public string name { get; set; }
        public long created_at { get; set; }
        public string phone_number { get; set; }
        public string description { get; set; }
        public long? email_verified_at { get; set; }
    }
}
