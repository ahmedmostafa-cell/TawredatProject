using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEvaluationDelivery
    {
        public Guid? DeliveryEvaluationId { get; set; }
        public string EvaluaterId { get; set; }
        public Guid? DeliveryId { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryEvaluationText { get; set; }
        public string StartsNo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
