using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbCharge
    {
        public Guid? ChargeId { get; set; }
        public string Id { get; set; }
      
        public string ChargeType { get; set; }
       
        public string ChargeValue { get; set; }
      
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
