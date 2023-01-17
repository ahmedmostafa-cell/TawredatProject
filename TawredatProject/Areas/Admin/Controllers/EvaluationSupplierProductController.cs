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
    public class EvaluationSupplierProductController : Controller
    {
        EvaluationSupplierProductService evaluationSupplierProductService;

        TawredatDbContext ctx;
        public EvaluationSupplierProductController(EvaluationSupplierProductService EvaluationSupplierProductService, TawredatDbContext context)
        {

            evaluationSupplierProductService = EvaluationSupplierProductService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,تقييم المنتج بالتاجر")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstEvaluationSupplierProducts = evaluationSupplierProductService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbEvaluationSupplierProduct ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SupplierProductEvaluationId == null)
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





                    var result = evaluationSupplierProductService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Evaluation Supplier Product Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Evaluation Supplier Product Profile  Creating.";
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






                    var result = evaluationSupplierProductService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Evaluation Supplier Product Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Evaluation Supplier Product Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstEvaluationSupplierProducts = evaluationSupplierProductService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف تقييم المنتج بالتاجر")]
        public IActionResult Delete(Guid id)
        {

            TbEvaluationSupplierProduct oldItem = ctx.TbEvaluationSupplierProducts.Where(a => a.SupplierProductEvaluationId == id).FirstOrDefault();



            var result = evaluationSupplierProductService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Evaluation Supplier Product Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Evaluation Supplier Product Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstEvaluationSupplierProducts = evaluationSupplierProductService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل تقييم المنتج بالتاجر")]
        public IActionResult Form(Guid? id)
        {
            TbEvaluationSupplierProduct oldItem = ctx.TbEvaluationSupplierProducts.Where(a => a.SupplierProductEvaluationId == id).FirstOrDefault();
            oldItem = ctx.TbEvaluationSupplierProducts.Where(a => a.SupplierProductEvaluationId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
