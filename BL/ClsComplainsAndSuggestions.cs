using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ComplainsAndSuggestionsService
    {
        List<TbComplainsAndSuggestion> getAll();
        bool Add(TbComplainsAndSuggestion client);
        bool Edit(TbComplainsAndSuggestion client);
        bool Delete(TbComplainsAndSuggestion client);


    }
    public class ClsComplainsAndSuggestions : ComplainsAndSuggestionsService
    {
        TawredatDbContext ctx;

        public ClsComplainsAndSuggestions(TawredatDbContext context)
        {
            ctx = context;
        }
        public List<TbComplainsAndSuggestion> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbComplainsAndSuggestion> lstComplainsAndSuggestions = ctx.TbComplainsAndSuggestions.ToList();

            return lstComplainsAndSuggestions;
        }

        public bool Add(TbComplainsAndSuggestion item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbComplainsAndSuggestions.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbComplainsAndSuggestion item)
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

        public bool Delete(TbComplainsAndSuggestion item)
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
