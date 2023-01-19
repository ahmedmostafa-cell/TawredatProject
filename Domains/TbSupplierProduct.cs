using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSupplierProduct
    {
        public Guid? SupplierProductId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنتج   ")]
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم التاجر   ")]
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ProductImage { get; set; }
        public string ProductEvaluationStars { get; set; }
        public string ProductEvaluationNumber { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل سعر المنتج   ")]
        public string ProductPrice { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المدينة   ")]
        public Guid? SupplierCityId { get; set; }
        public string SupplierCityName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل قسم المنتج   ")]
        public Guid? ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اقصي كمية مسموحة للبيع    ")]
        public string ProductMaximumSaleQty { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف المنتج   ")]
        public string ProductDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int CurrentState { get; set; }
    }
}
