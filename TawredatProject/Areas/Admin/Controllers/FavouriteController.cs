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
    public class FavouriteController : Controller
    {
        FavouriteService favouriteService;

        TawredatDbContext ctx;
        public FavouriteController(FavouriteService FavouriteService, TawredatDbContext context)
        {

            favouriteService = FavouriteService;
            ctx = context;

        }

        [Authorize(Roles = "Admin,المفضلات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstFavourites = favouriteService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbFavourite ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.FavouritesId == null)
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





                    var result = favouriteService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Favourite Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Favourite Profile  Creating.";
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






                    var result = favouriteService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Favourite Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Favourite Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstFavourites = favouriteService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف المفضلات")]
        public IActionResult Delete(Guid id)
        {

            TbFavourite oldItem = ctx.TbFavourites.Where(a => a.FavouritesId == id).FirstOrDefault();



            var result = favouriteService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Favourite Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Favourite Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstFavourites = favouriteService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل المفضلات")]
        public IActionResult Form(Guid? id)
        {
            TbFavourite oldItem = ctx.TbFavourites.Where(a => a.FavouritesId == id).FirstOrDefault();
            oldItem = ctx.TbFavourites.Where(a => a.FavouritesId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
