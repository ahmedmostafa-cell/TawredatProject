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
    public class SupplierProductController : Controller
    {
        ProductCategoryService productCategoryService;
        CityService cityService;
        SupplierProductService supplierProductService;
        SupplierService supplierService;
        ProductService productService;
        TawredatDbContext ctx;
        public SupplierProductController(ProductCategoryService ProductCategoryService,CityService CityService,SupplierService SupplierService,ProductService ProductService,SupplierProductService SupplierProductService, TawredatDbContext context)
        {

            supplierProductService = SupplierProductService;
            ctx = context;
            productService = ProductService;
            supplierService = SupplierService;
            cityService = CityService;
            productCategoryService = ProductCategoryService;

        }
        [Authorize(Roles = "Admin,منتجات التجار")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSupplierProducts = supplierProductService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSupplierProduct ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SupplierProductId == null)
            {
                ITEM.SupplierName = supplierService.getAll().Where(a => a.SupplierId == ITEM.SupplierId).FirstOrDefault().SupplierName;
                ITEM.ProductName = productService.getAll().Where(a => a.ProductId == ITEM.ProductId).FirstOrDefault().ProductName;

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





                    var result = supplierProductService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Product Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Product Profile  Creating.";
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






                    var result = supplierProductService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Product Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Product Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSupplierProducts = supplierProductService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف منتجات التجار")]
        public IActionResult Delete(Guid id)
        {

            TbSupplierProduct oldItem = ctx.TbSupplierProducts.Where(a => a.SupplierProductId == id).FirstOrDefault();



            var result = supplierProductService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Supplier Product Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Supplier Product Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSupplierProducts = supplierProductService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل منتجات التجار")]
        public IActionResult Form(Guid? id)
        {
            TbSupplierProduct oldItem = ctx.TbSupplierProducts.Where(a => a.SupplierProductId == id).FirstOrDefault();
            oldItem = ctx.TbSupplierProducts.Where(a => a.SupplierProductId == id).FirstOrDefault();
            ViewBag.cities = productService.getAll();
            ViewBag.suppliers = supplierService.getAll();
            ViewBag.realCities = cityService.getAll();
            ViewBag.productCategories = productCategoryService.getAll();
            return View(oldItem);
        }
    }
}
