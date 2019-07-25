using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        public string CatPic { get; set; }
        public string CatKeywords { get; set; }
        public string CatStatus { get; set; }
        public string AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Extra { get; set; }
    }
}
