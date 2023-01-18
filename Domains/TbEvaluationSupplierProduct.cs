using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEvaluationSupplierProduct
    {
        public Guid? SupplierProductEvaluationId { get; set; }
        public string EvaluaterId { get; set; }
        public string ToBeEvaluatedId { get; set; }
        public string SupplierProductEevaluationText { get; set; }
        public string StartsNo { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
