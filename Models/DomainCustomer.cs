using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class DomainCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerCompany { get; set; }
        public string CustomerAddresss { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
