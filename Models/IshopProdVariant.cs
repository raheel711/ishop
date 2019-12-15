using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class IshopProdVariant
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public string VariantTitle { get; set; }
        public string VariantDetail { get; set; }
        public string VariantShortDesc { get; set; }
        public string VariantFeatureImg { get; set; }
        public string VariantPic2 { get; set; }
        public bool Status { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
