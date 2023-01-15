using System;
using System.Collections.Generic;

#nullable disable

namespace BL.Models
{
    public partial class TbDelivery
    {
        public Guid DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }
        public string DeliveryManEvaluationStarts { get; set; }
        public string DeliveryManEvaluationNumber { get; set; }
        public Guid? DeliveryManCityId { get; set; }
        public string DeliveryManCityName { get; set; }
        public Guid? DeliveryManAreaId { get; set; }
        public string DeliveryManAreaName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
