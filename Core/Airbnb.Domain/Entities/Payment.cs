using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public int reservation_id { get; set; }
        public bool status { get; set; }
        public string credit_card_number { get; set; }
        public int credit_card_CCV { get; set; }
        public DateTime card_expiration_date { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string billing_address { get; set; }
    }
}
