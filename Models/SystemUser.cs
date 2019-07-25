using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class SystemUser
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string SuUsername { get; set; }
        public string SuPassword { get; set; }
        public string SuStatus { get; set; }
        public string SuProfilePic { get; set; }
        public string SuRole { get; set; }
        public string AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Extra { get; set; }
        public string SuEmail { get; set; }

    }
}
