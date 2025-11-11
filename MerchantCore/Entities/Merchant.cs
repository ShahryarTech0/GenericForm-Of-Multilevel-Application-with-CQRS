using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantCore.Entities
{
    public class Merchant
    {
        [Key]
        public int ID { get; set; }
        public string? MerchantCode { get; set; }
        public string? MerchantName { get; set; }
        public string? MerchantAddress { get; set; }

        public string? Email { get; set; }
        public string? OtherEmail { get; set; }
        public string? Number { get; set; }
        public string? OtherNumber { get; set; }
        public string? City { get; set; }

        public int Area { get; set; }
        public int Zone { get; set; }


        // Navigation property - one merchant has many locations
        public ICollection<MerchantLocation> merchantlocations { get; set; }

    }
}
