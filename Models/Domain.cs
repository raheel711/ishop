using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class Domain
    {
        public int Id { get; set; }
        public string Domain1 { get; set; }
        public int CustomerId { get; set; }
        public string OnlineDb { get; set; }
        public string OnlineUs { get; set; }
        public string OnlinePass { get; set; }
        public bool Status { get; set; }
        public DateTime? DomainRegDate { get; set; }
        public DateTime? DomainExpiryDate { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
