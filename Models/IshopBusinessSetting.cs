using System;
using System.Collections.Generic;

namespace ishop.Models
{
    public partial class IshopBusinessSetting
    {
        public int Id { get; set; }
        public int DomainId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessTitle { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessPhoneNo { get; set; }
        public string BusinessCellNo { get; set; }
        public string BusinessFaxNo { get; set; }
        public string BusinessAddressOffice { get; set; }
        public string BusinessAddressFactory { get; set; }
        public string BusinessEmailReceived { get; set; }
        public string BusinessOwnerName { get; set; }
        public string BusinessCopyRight { get; set; }
    }
}
