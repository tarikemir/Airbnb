using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Entities
{
    public class Owner
    {
        [Key]
        public int id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public DateTime email_verified_at { get; set; }
        public DateTime created_at { get; set; }
        public string remember_token { get; set; }
        public string phone_num { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public DateTime updated_at { get; set; }
    }
}
