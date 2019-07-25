using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string ProdKeywords { get; set; }
        public string ItemCode { get; set; }
        public string Qty { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public string ProdStatus { get; set; }
        public string AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Extra { get; set; }
    }
}
