using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class IshopProduct
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProdName { get; set; }
        public string ItemCode { get; set; }
        public string ProdFeatureImg { get; set; }
        public string ProPic2 { get; set; }
        public string ProdShortDetail { get; set; }
        public string ProdDetail { get; set; }
        public string ProdKeywords { get; set; }
        public bool Status { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsFeature { get; set; }
        public int Ranking { get; set; }
        public string ProdPermalink { get; set; }
        public string ProdMetaTitle { get; set; }
        public string ProdMetaDescription { get; set; }
        public string ProdMetaKeyword { get; set; }
        public string GoogleCateory { get; set; }
        public int? HitUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Extra { get; set; }
    }
}
