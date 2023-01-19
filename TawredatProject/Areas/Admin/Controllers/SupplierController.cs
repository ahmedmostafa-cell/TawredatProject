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
using Microsoft.AspNetCore.Identity;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        SupplierService supplierService;
        CityService cityService;
        TawredatDbContext ctx;
        public SupplierController(CityService CityService,SupplierService SupplierService, TawredatDbContext context)
        {

            supplierService = SupplierService;
            ctx = context;
            cityService = CityService;

        }
        [Authorize(Roles = "Admin,التجار")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSuppliers = supplierService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSupplier ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SupplierId == null)
            {
                ITEM.SupplierCityName = cityService.getAll().Where(a => a.CityId == ITEM.SupplierCityId).FirstOrDefault().CityName;

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
                            ITEM.SupplierImage = ImageName;
                        }
                    }





                    var result = supplierService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Profile  Creating.";
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
                            ITEM.SupplierImage = ImageName;
                        }
                    }






                    var result = supplierService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSuppliers = supplierService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف التجار")]
        public IActionResult Delete(Guid id)
        {

            TbSupplier oldItem = ctx.TbSuppliers.Where(a => a.SupplierId == id).FirstOrDefault();



            var result = supplierService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Supplier Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Supplier Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSuppliers = supplierService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل التجار")]
        public IActionResult Form(Guid? id)
        {
            TbSupplier oldItem = ctx.TbSuppliers.Where(a => a.SupplierId == id).FirstOrDefault();
            oldItem = ctx.TbSuppliers.Where(a => a.SupplierId == id).FirstOrDefault();
            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
