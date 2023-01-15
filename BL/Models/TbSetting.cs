using System;
using System.Collections.Generic;

#nullable disable

namespace BL.Models
{
    public partial class TbSetting
    {
        public Guid SettingId { get; set; }
        public string ValueAddedTax { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
