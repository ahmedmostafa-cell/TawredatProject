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
    public class AddressController : Controller
    {
        AddressService addressService;

        TawredatDbContext ctx;
        public AddressController(AddressService AddressService, TawredatDbContext context)
        {

            addressService = AddressService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,العناوين")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstAddresses = addressService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbAddress ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.AddressId == null)
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





                    var result = addressService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Address Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Address Profile  Creating.";
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






                    var result = addressService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Address Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Address Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstAddresses = addressService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف العناوين")]
        public IActionResult Delete(Guid id)
        {

            TbAddress oldItem = ctx.TbAddresses.Where(a => a.AddressId == id).FirstOrDefault();



            var result = addressService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Address Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Address Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstAddresses = addressService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل العناوين")]
        public IActionResult Form(Guid? id)
        {
            TbAddress oldItem = ctx.TbAddresses.Where(a => a.AddressId == id).FirstOrDefault();
            oldItem = ctx.TbAddresses.Where(a => a.AddressId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
