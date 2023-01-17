using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SalesInvoiceProductService
    {
        List<TbSalesInvoiceProduct> getAll();
        bool Add(TbSalesInvoiceProduct client);
        bool Edit(TbSalesInvoiceProduct client);
        bool Delete(TbSalesInvoiceProduct client);


    }
    public class ClsSalesInvoiceProduct : SalesInvoiceProductService
    {
        TawredatDbContext ctx;

        public ClsSalesInvoiceProduct(TawredatDbContext context)
        {
            ctx = context;
        }
        public List<TbSalesInvoiceProduct> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSalesInvoiceProduct> lstAboutApps = ctx.TbSalesInvoiceProducts.ToList();

            return lstAboutApps;
        }

        public bool Add(TbSalesInvoiceProduct item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbSalesInvoiceProducts.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSalesInvoiceProduct item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbSalesInvoiceProduct item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
