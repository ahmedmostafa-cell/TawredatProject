using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbPaymentMethod
    {
        public Guid? PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
