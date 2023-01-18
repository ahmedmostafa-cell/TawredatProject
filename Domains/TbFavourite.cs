using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbFavourite
    {
        public Guid? FavouritesId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ProductEvaluationStarts { get; set; }
        public string ProductEvaluationNumber { get; set; }
        public string ProductPrice { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
