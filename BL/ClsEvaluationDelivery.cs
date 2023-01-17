using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface EvaluationDeliveryService
    {
        List<TbEvaluationDelivery> getAll();
        bool Add(TbEvaluationDelivery client);
        bool Edit(TbEvaluationDelivery client);
        bool Delete(TbEvaluationDelivery client);


    }
    public class ClsEvaluationDelivery : EvaluationDeliveryService
    {
        TawredatDbContext ctx;

        public ClsEvaluationDelivery(TawredatDbContext context)
        {
            ctx = context;
        }
        public List<TbEvaluationDelivery> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbEvaluationDelivery> lstEvaluationDeliveries = ctx.TbEvaluationDeliveries.ToList();

            return lstEvaluationDeliveries;
        }

        public bool Add(TbEvaluationDelivery item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbEvaluationDeliveries.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbEvaluationDelivery item)
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

        public bool Delete(TbEvaluationDelivery item)
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
