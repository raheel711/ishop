using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class IshopProdImgGallery
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public int? VariantId { get; set; }
        public string ImgUrl { get; set; }
        public bool? Status { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
