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
    public class ProductController : Controller
    {
        ProductService productService;
        ProductCategoryService productCategoryService;
        TawredatDbContext ctx;
        public ProductController(ProductCategoryService ProductCategoryService,ProductService ProductService, TawredatDbContext context)
        {

            productService = ProductService;
            ctx = context;
            productCategoryService = ProductCategoryService;

        }
        [Authorize(Roles = "Admin,المنتجات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstProducts = productService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbProduct ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.ProductId == null)
            {
                ITEM.ProductCategoryName = productCategoryService.getAll().Where(a => a.ProductCategoryId == ITEM.ProductCategoryId).FirstOrDefault().ProductCategoryName;

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

                    if(ITEM.DiscountPercent!=null) 
                    {
                        int newPrice = int.Parse(ITEM.ProductPrice) - ((int.Parse(ITEM.ProductPrice) * int.Parse(ITEM.DiscountPercent)) / 100);
                        ITEM.ProductNewPrice = newPrice.ToString();
                    }



                    var result = productService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Product Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Product Profile  Creating.";
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



                    if (ITEM.DiscountPercent != null)
                    {
                        int newPrice = int.Parse(ITEM.ProductPrice) - ((int.Parse(ITEM.ProductPrice) * int.Parse(ITEM.DiscountPercent)) / 100);
                        ITEM.ProductNewPrice = newPrice.ToString();
                    }


                    var result = productService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Product Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Product Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstProducts = productService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف المنتجات")]
        public IActionResult Delete(Guid id)
        {

            TbProduct oldItem = ctx.TbProducts.Where(a => a.ProductId == id).FirstOrDefault();



            var result = productService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Product Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Product Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstProducts = productService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل المنتجات")]
        public IActionResult Form(Guid? id)
        {
            TbProduct oldItem = ctx.TbProducts.Where(a => a.ProductId == id).FirstOrDefault();
            oldItem = ctx.TbProducts.Where(a => a.ProductId == id).FirstOrDefault();
            ViewBag.cities = productCategoryService.getAll();
            return View(oldItem);
        }
    }
}
