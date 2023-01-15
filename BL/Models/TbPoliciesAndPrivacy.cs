using System;
using System.Collections.Generic;

#nullable disable

namespace BL.Models
{
    public partial class TbPoliciesAndPrivacy
    {
        public Guid PoliciesAndPrivacyId { get; set; }
        public string PoliciesAndPrivacyTitle { get; set; }
        public string PoliciesAndPrivacyDescription { get; set; }
        public string PoliciesAndPrivacyForWhom { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public string CurrentState { get; set; }
    }
}
