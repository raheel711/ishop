using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class IshopProdPricing
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public double Qty { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
    }
}
