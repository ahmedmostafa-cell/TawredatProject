using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbAboutApp
    {
        public Guid? AboutAppId { get; set; }
        public string AboutAppTitle { get; set; }
        public string AboutAppDescription { get; set; }
        public string AboutAppForWhom { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
