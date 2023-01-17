using BL;
using Domains;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TawredatProject.Models
{
    public class HomePageModel
    {
        #region Declaration


        public IEnumerable<ApplicationUser> UserData { get; set; }

        public string ImageProfile { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

      

        public ApplicationUser OneUser { get; set; }


        public IEnumerable<ApplicationUser> lstUsers { get; set; }

       

        public IEnumerable<TbAboutApp> lstAboutApp { get; set; }

       

        public IEnumerable<TbCharge> lstCharges { get; set; }


        public IEnumerable<TbComplainsAndSuggestion> lstComplainsAndSuggestions { get; set; }


        

        public IEnumerable<TbNotification> lstNotifications { get; set; }

        public IEnumerable<TbOffer> lstOffers { get; set; }

        public IEnumerable<TbPoliciesAndPrivacy> lstPoliciesAndPrivacy { get; set; }

        public IEnumerable<TbPromocode> lstPromocodes { get; set; }

        public IEnumerable<TbSetting> lstSettings { get; set; }


       

        public IEnumerable<TbTermAndCondition> lstTermAndConditions { get; set; }


        public IEnumerable<TbAddress> lstAddresses { get; set; }


        public IEnumerable<TbCity> lstCities { get; set; }

        public IEnumerable<TbDelivery> lstDeliveries { get; set; }


        public IEnumerable<TbEvaluationDelivery> lstEvaluationDeliveries { get; set; }


        public IEnumerable<TbEvaluationSupplierProduct> lstEvaluationSupplierProducts { get; set; }


        public IEnumerable<TbFavourite> lstFavourites { get; set; }

        public IEnumerable<TbPaymentMethod> lstPaymentMethods { get; set; }

        public IEnumerable<TbProduct> lstProducts { get; set; }

        public IEnumerable<TbProductCategory> lstProductCategories { get; set; }

        public IEnumerable<TbPurchasingCart> lstPurchasingCarts { get; set; }


        public IEnumerable<TbSalesInvoice> lstSalesInvoices { get; set; }

        public IEnumerable<TbSalesInvoiceProduct> lstSalesInvoiceProducts { get; set; }


        public IEnumerable<TbSlider> lstSliders { get; set; }

        public IEnumerable<TbSupplier> lstSuppliers { get; set; }

        public IEnumerable<TbSupplierProduct> lstSupplierProducts { get; set; }








        #endregion
    }
}
