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
    public class ProductCategoryController : Controller
    {
        ProductCategoryService productCategoryService;

        TawredatDbContext ctx;
        public ProductCategoryController(ProductCategoryService ProductCategoryService, TawredatDbContext context)
        {

            productCategoryService = ProductCategoryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,اقسام المنتجات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstProductCategories = productCategoryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbProductCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.ProductCategoryId == null)
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
                            ITEM.ProductCategoryImage = ImageName;
                        }
                    }





                    var result = productCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Product Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Product Category Profile  Creating.";
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
                            ITEM.ProductCategoryImage = ImageName;
                        }
                    }






                    var result = productCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Product Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Product Category Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstProductCategories = productCategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف اقسام المنتجات")]
        public IActionResult Delete(Guid id)
        {

            TbProductCategory oldItem = ctx.TbProductCategories.Where(a => a.ProductCategoryId == id).FirstOrDefault();



            var result = productCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Product Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Product Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstProductCategories = productCategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل اقسام المنتجات")]
        public IActionResult Form(Guid? id)
        {
            TbProductCategory oldItem = ctx.TbProductCategories.Where(a => a.ProductCategoryId == id).FirstOrDefault();
            oldItem = ctx.TbProductCategories.Where(a => a.ProductCategoryId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
