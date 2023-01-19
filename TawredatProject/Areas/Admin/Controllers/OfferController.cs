using TawredatProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : Controller
    {
        ProductCategoryService productCategoryService;
        CityService cityService;
        SupplierProductService supplierProductService;
        SupplierService supplierService;
        ProductService productService;
        OfferService offerService;
        TawredatDbContext ctx;
        public OfferController(OfferService OfferService, ProductCategoryService ProductCategoryService, CityService CityService, SupplierService SupplierService, ProductService ProductService, SupplierProductService SupplierProductService, TawredatDbContext context)
        {
            offerService = OfferService;
            supplierProductService = SupplierProductService;
            ctx = context;
            productService = ProductService;
            supplierService = SupplierService;
            cityService = CityService;
            productCategoryService = ProductCategoryService;

        }
        [Authorize(Roles = "Admin,العروض")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstOffers = offerService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbOffer ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.OfferId == null)
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





                    var result = offerService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Offer Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Offer Profile  Creating.";
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






                    var result = offerService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Offer Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Offer Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstOffers = offerService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف العروض")]
        public IActionResult Delete(Guid id)
        {

            TbOffer oldItem = ctx.TbOffers.Where(a => a.OfferId == id).FirstOrDefault();



            var result = offerService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Offer Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Offer Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstOffers = offerService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل العروض")]
        public IActionResult Form(Guid? id)
        {
            TbOffer oldItem = ctx.TbOffers.Where(a => a.OfferId == id).FirstOrDefault();
            oldItem = ctx.TbOffers.Where(a => a.OfferId == id).FirstOrDefault();
            ViewBag.cities = productService.getAll();
            ViewBag.suppliers = supplierService.getAll();
            ViewBag.realCities = cityService.getAll();
            ViewBag.productCategories = productCategoryService.getAll();
            return View(oldItem);
        }
    }
}
