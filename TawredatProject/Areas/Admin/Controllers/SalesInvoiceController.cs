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
    public class SalesInvoiceController : Controller
    {
        SalesInvoiceService salesInvoiceService;

        TawredatDbContext ctx;
        public SalesInvoiceController(SalesInvoiceService SalesInvoiceService, TawredatDbContext context)
        {

            salesInvoiceService = SalesInvoiceService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,فاتورة البيع")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSalesInvoices = salesInvoiceService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSalesInvoice ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SalesInvoiceId == null)
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





                    var result = salesInvoiceService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Sales Invoice Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Sales Invoice Profile  Creating.";
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






                    var result = salesInvoiceService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Sales Invoice Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Sales Invoice Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSalesInvoices = salesInvoiceService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف فاتورة البيع")]
        public IActionResult Delete(Guid id)
        {

            TbSalesInvoice oldItem = ctx.TbSalesInvoices.Where(a => a.SalesInvoiceId == id).FirstOrDefault();



            var result = salesInvoiceService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Sales Invoice Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Sales Invoice Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSalesInvoices = salesInvoiceService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل فاتورة البيع")]
        public IActionResult Form(Guid? id)
        {
            TbSalesInvoice oldItem = ctx.TbSalesInvoices.Where(a => a.SalesInvoiceId == id).FirstOrDefault();
            oldItem = ctx.TbSalesInvoices.Where(a => a.SalesInvoiceId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
