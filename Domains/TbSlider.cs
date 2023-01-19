using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSlider
    {
        public Guid? SliderId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان السليدر   ")]
        public string SliderTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل تفاصيل السليدر   ")]
        public string SliderText { get; set; }
        public string SliderImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل ترتيب السليدر   ")]
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل مكان السليدر   ")]
        public string SliderLocation { get; set; }
    }
}
