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
    public class SalesInvoiceProductController : Controller
    {
        SalesInvoiceProductService salesInvoiceProductService;

        TawredatDbContext ctx;
        public SalesInvoiceProductController(SalesInvoiceProductService SalesInvoiceProductService, TawredatDbContext context)
        {

            salesInvoiceProductService = SalesInvoiceProductService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,تفاصيل فاتورة البيع")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSalesInvoiceProducts = salesInvoiceProductService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSalesInvoiceProduct ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SalesInvoiceProductId == null)
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





                    var result = salesInvoiceProductService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Sales Invoice Details Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Sales Invoice Details Profile  Creating.";
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






                    var result = salesInvoiceProductService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Sales Invoice Details Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Sales Invoice Details Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSalesInvoiceProducts = salesInvoiceProductService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف تفاصيل فاتورة البيع")]
        public IActionResult Delete(Guid id)
        {

            TbSalesInvoiceProduct oldItem = ctx.TbSalesInvoiceProducts.Where(a => a.SalesInvoiceProductId == id).FirstOrDefault();



            var result = salesInvoiceProductService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Sales Invoice Details Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Sales Invoice Details Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSalesInvoiceProducts = salesInvoiceProductService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل تفاصيل فاتورة البيع")]
        public IActionResult Form(Guid? id)
        {
            TbSalesInvoiceProduct oldItem = ctx.TbSalesInvoiceProducts.Where(a => a.SalesInvoiceProductId == id).FirstOrDefault();
            oldItem = ctx.TbSalesInvoiceProducts.Where(a => a.SalesInvoiceProductId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
