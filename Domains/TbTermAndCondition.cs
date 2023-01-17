using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbTermAndCondition
    {
        public Guid TermsAndConditionsId { get; set; }
        public string TermsAndConditionsTitle { get; set; }
        public string TermsAndConditionsDescription { get; set; }
        public string TermsAndConditionsForWhom { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
