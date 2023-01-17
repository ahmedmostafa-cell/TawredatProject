using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface EvaluationSupplierProductService
    {
        List<TbEvaluationSupplierProduct> getAll();
        bool Add(TbEvaluationSupplierProduct client);
        bool Edit(TbEvaluationSupplierProduct client);
        bool Delete(TbEvaluationSupplierProduct client);


    }
    public class ClsEvaluationSupplierProduct : EvaluationSupplierProductService
    {
        TawredatDbContext ctx;

        public ClsEvaluationSupplierProduct(TawredatDbContext context)
        {
            ctx = context;
        }
        public List<TbEvaluationSupplierProduct> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbEvaluationSupplierProduct> lstEvaluationSupplierProducts = ctx.TbEvaluationSupplierProducts.ToList();

            return lstEvaluationSupplierProducts;
        }

        public bool Add(TbEvaluationSupplierProduct item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbEvaluationSupplierProducts.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbEvaluationSupplierProduct item)
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

        public bool Delete(TbEvaluationSupplierProduct item)
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
