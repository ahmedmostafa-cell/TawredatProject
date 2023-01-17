using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbAddress
    {
        public Guid? AddressId { get; set; }
        public string Id { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم صاحب العنوان")]
        public string Name { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل خطوط الطول")]
        public string AddressLatitude { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل خطوط العرض")]
        public string Addresslongitude { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الشارع")]
        public string AddressStreet { get; set; }
        public Guid? AddressAreaId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنطقة")]
        public string AddressArea { get; set; }
        public Guid? AddressCityId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المدينة")]
        public string AddressCity { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الدولة")]
        public string AddressCountry { get; set; }
        [Required(ErrorMessage = "من فضلك هل عنوان رئيسي")]
        public string MainAddress { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل رقم التليفون")]
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
