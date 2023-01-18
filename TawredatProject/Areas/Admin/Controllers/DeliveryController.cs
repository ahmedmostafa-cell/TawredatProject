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
using Microsoft.AspNetCore.Identity;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeliveryController : Controller
    {
        CityService cityService;
        DeliveryService deliveryService;

        TawredatDbContext ctx;
        public DeliveryController(CityService CityService,DeliveryService DeliveryService, TawredatDbContext context)
        {

            deliveryService = DeliveryService;
            ctx = context;
            cityService = CityService;

        }
        [Authorize(Roles = "Admin,رجال التوصيل")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstDeliveries = deliveryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbDelivery ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.DeliveryManId == null)
            {
                ITEM.DeliveryManCityName = cityService.getAll().Where(a => a.CityId == ITEM.DeliveryManCityId).FirstOrDefault().CityName;

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





                    var result = deliveryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Delivery Man Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Delivery Man Profile  Creating.";
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






                    var result = deliveryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Delivery Man Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Delivery Man Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstDeliveries = deliveryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف رجال التوصيل")]
        public IActionResult Delete(Guid id)
        {

            TbDelivery oldItem = ctx.TbDeliveries.Where(a => a.DeliveryManId == id).FirstOrDefault();



            var result = deliveryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Delivery Man Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Delivery Man Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstDeliveries = deliveryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل رجال التوصيل")]
        public IActionResult Form(Guid? id)
        {
            TbDelivery oldItem = ctx.TbDeliveries.Where(a => a.DeliveryManId == id).FirstOrDefault();
            oldItem = ctx.TbDeliveries.Where(a => a.DeliveryManId == id).FirstOrDefault();
            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
