using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using TawredatProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentMethodController : Controller
    {
        PaymentMethodService paymentMethodService;

        TawredatDbContext ctx;
        public PaymentMethodController(PaymentMethodService PaymentMethodService, TawredatDbContext context)
        {

            paymentMethodService = PaymentMethodService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,طرق الدفع")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstPaymentMethods = paymentMethodService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbPaymentMethod ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.PaymentMethodId == null)
            {


                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.ab = ImageName;
                    //    }
                    //}





                    var result = paymentMethodService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Payment Method Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Payment Method Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.MainConsultingImage = ImageName;
                    //    }
                    //}






                    var result = paymentMethodService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Payment Method Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Payment Method Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstPaymentMethods = paymentMethodService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف طرق الدفع")]
        public IActionResult Delete(Guid id)
        {

            TbPaymentMethod oldItem = ctx.TbPaymentMethods.Where(a => a.PaymentMethodId == id).FirstOrDefault();



            var result = paymentMethodService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Payment Method Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Payment Method Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstPaymentMethods = paymentMethodService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل طرق الدفع")]
        public IActionResult Form(Guid? id)
        {
            TbPaymentMethod oldItem = ctx.TbPaymentMethods.Where(a => a.PaymentMethodId == id).FirstOrDefault();
            oldItem = ctx.TbPaymentMethods.Where(a => a.PaymentMethodId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
