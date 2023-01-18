using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSalesInvoiceProduct
    {
        public Guid? SalesInvoiceProductId { get; set; }
        public Guid? SalesInvoiceId { get; set; }
        public string DelivryDate { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid? DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductPrice { get; set; }
        public string Promocode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DiscountPercent { get; set; }
        public string ProductPriceAfterDiscount { get; set; }
        public string ProductQty { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public Guid? PaymnetMethodId { get; set; }
        public string PaymnetMethodName { get; set; }
        public string TotalProductValue { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
