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
    public class EvaluationDeliveryController : Controller
    {
        EvaluationDeliveryService evaluationDeliveryService;

        TawredatDbContext ctx;
        public EvaluationDeliveryController(EvaluationDeliveryService EvaluationDeliveryService, TawredatDbContext context)
        {

            evaluationDeliveryService = EvaluationDeliveryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,تقييم رجال التوصيل")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstEvaluationDeliveries = evaluationDeliveryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbEvaluationDelivery ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.DeliveryEvaluationId == null)
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





                    var result = evaluationDeliveryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "EvaluationDelivery Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in EvaluationDelivery Profile  Creating.";
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






                    var result = evaluationDeliveryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "EvaluationDelivery Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in EvaluationDelivery Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstEvaluationDeliveries = evaluationDeliveryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف تقييم رجال التوصيل")]
        public IActionResult Delete(Guid id)
        {

            TbEvaluationDelivery oldItem = ctx.TbEvaluationDeliveries.Where(a => a.DeliveryEvaluationId == id).FirstOrDefault();



            var result = evaluationDeliveryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "EvaluationDelivery Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in EvaluationDelivery Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstEvaluationDeliveries = evaluationDeliveryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل تقييم رجال التوصيل")]
        public IActionResult Form(Guid? id)
        {
            TbEvaluationDelivery oldItem = ctx.TbEvaluationDeliveries.Where(a => a.DeliveryEvaluationId == id).FirstOrDefault();
            oldItem = ctx.TbEvaluationDeliveries.Where(a => a.DeliveryEvaluationId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
