using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Entities
{
    public class Review
    {
        [Key]
        public int id { get; set; }
        public int reservation_id { get; set; }
        public float rating { get; set; }
        public string comment { get; set; }
    }
}
