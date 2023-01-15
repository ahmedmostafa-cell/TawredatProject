using System;
using System.Collections.Generic;

#nullable disable

namespace BL.Models
{
    public partial class TbPromocode
    {
        public Guid PromocodeId { get; set; }
        public string PromocodeTitle { get; set; }
        public string PromocodeDiscountPercent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
