using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class IshopCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string CatName { get; set; }
        public string CatShortDetail { get; set; }
        public string CatDetail { get; set; }
        public string CatFeatureImg { get; set; }
        public string CatPic2 { get; set; }
        public string CatKeywords { get; set; }
        public bool Status { get; set; }
        public bool IsFeature { get; set; }
        public int Ranking { get; set; }
        public string CatPermalink { get; set; }
        public string CatMetatag { get; set; }
        public bool? ShowMenu { get; set; }
        public bool? ShowFooter { get; set; }
        public bool? ShowHome { get; set; }
        public string GoogleCategory { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Extra { get; set; }
    }
}
