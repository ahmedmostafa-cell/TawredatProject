using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbOffer
    {
        public Guid? OfferId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنتج   ")]
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم التاجر   ")]
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "من فضلك اسعر قبل العرض   ")]
        public string PriceBeforeOffer { get; set; }
        [Required(ErrorMessage = "من فضلك اسعر بعد العرض   ")]
        public string PriceAfterOffer { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل قسم المنتج   ")]
        public Guid? ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductEvaluationStarts { get; set; }
        public string ProductEvaluationNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
