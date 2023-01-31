using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL
{
    public class ApplicationUser:IdentityUser
    {
     


       


        public string? OTP { get; set; }

        public string? Image { get; set; }



        public string? FirstName { get; set; }

        public string? FamilyName { get; set; }

        public string? CityName { get; set; }

        public string? CityId { get; set; }


        public string? ClinicName { get; set; }
        public string? Status { get; set; }

        public string? Latitude { get; set; }
        public string? Longitute { get; set; }
        public string? Location { get; set; }
      


        [NotMapped]
        public string? RoleId { get; set; }
        [NotMapped]
        public string? Role { get; set; }

        [NotMapped]
        public List<SelectListItem>? RoleList { get; set; }


        [NotMapped]
        public List<SelectListItem>? RoleList2 { get; set; }
        [NotMapped]
        public List<string>? RoleList3 { get; set; }


        [NotMapped]
        public IEnumerable<IdentityRole>? RoleListMain { get; set; }


    }
}
