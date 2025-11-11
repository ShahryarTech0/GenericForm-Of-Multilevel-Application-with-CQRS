using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Dto
{
    public class MerchantDto
    {
        [Key]
        public int ID { get; set; }
        public string? Location { get; set; }
        public int? ParentID { get; set; }
        public int MerchantId { get; set; } // FK to Merchant
        public string? Address { get; set; }
        public string? POCName { get; set; }
        public string? POCEmail { get; set; }
        public string? POCNumber { get; set; }
        public string? OtherEmail { get; set; }
        public string? OtherNumber { get; set; }
    }
}
