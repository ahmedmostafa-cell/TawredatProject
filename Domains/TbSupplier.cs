using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSupplier
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEvaluationStars { get; set; }
        public string SupplierEvaluationNumber { get; set; }
        public string SupplierImage { get; set; }
        public string CustomersNumber { get; set; }
        public Guid? SupplierCityId { get; set; }
        public string SupplierCityName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
