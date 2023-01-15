using System;
using System.Collections.Generic;

#nullable disable

namespace BL.Models
{
    public partial class TbAddress
    {
        public Guid AddressId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string AddressLatitude { get; set; }
        public string Addresslongitude { get; set; }
        public string AddressStreet { get; set; }
        public Guid? AddressAreaId { get; set; }
        public string AddressArea { get; set; }
        public Guid? AddressCityId { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string MainAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Otp { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
