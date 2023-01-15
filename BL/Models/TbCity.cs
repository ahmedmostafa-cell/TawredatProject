﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BL.Models
{
    public partial class TbCity
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
