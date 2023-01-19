using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbProductCategory
    {
        public Guid? ProductCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم  قسم المنتج ")]
        public string ProductCategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف  قسم المنتج ")]
        public string ProductCategoryDescription { get; set; }
        public string ProductCategoryImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
