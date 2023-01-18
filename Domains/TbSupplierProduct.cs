using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSupplierProduct
    {
        public Guid? SupplierProductId { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ProductImage { get; set; }
        public string ProductEvaluationStars { get; set; }
        public string ProductEvaluationNumber { get; set; }
        public string ProductPrice { get; set; }
        public Guid? SupplierCityId { get; set; }
        public string SupplierCityName { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductMaximumSaleQty { get; set; }
        public string ProductDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int CurrentState { get; set; }
    }
}
