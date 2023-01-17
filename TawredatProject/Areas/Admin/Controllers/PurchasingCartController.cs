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
using System.IO;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PurchasingCartController : Controller
    {
        PurchasingCartService purchasingCartService;

        TawredatDbContext ctx;
        public PurchasingCartController(PurchasingCartService PurchasingCartService, TawredatDbContext context)
        {

            purchasingCartService = PurchasingCartService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,سلة المشتريات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstPurchasingCarts = purchasingCartService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbPurchasingCart ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.PurchasingCartId == null)
            {


                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.ProductImage = ImageName;
                        }
                    }





                    var result = purchasingCartService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Purchasing Cart Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Purchasing Cart Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.ProductImage = ImageName;
                        }
                    }






                    var result = purchasingCartService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Purchasing Cart Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Purchasing Cart Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstPurchasingCarts = purchasingCartService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف سلة المشتريات")]
        public IActionResult Delete(Guid id)
        {

            TbPurchasingCart oldItem = ctx.TbPurchasingCarts.Where(a => a.PurchasingCartId == id).FirstOrDefault();



            var result = purchasingCartService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Purchasing Cart Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Purchasing Cart Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstPurchasingCarts = purchasingCartService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل سلة المشتريات")]
        public IActionResult Form(Guid? id)
        {
            TbPurchasingCart oldItem = ctx.TbPurchasingCarts.Where(a => a.PurchasingCartId == id).FirstOrDefault();
            oldItem = ctx.TbPurchasingCarts.Where(a => a.PurchasingCartId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
