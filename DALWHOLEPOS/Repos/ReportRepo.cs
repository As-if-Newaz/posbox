using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class ReportRepo : Repo, IRepo<Report, int, bool>
    {
        public bool Create(Report obj)
        {
            db.Reports.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Reports.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Report> Get()
        {
            return db.Reports.Where(p => p.IsDeleted == false).ToList();
        }

        public Report Get(int id)
        {
            return db.Reports.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Report obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            } 

            if (!string.IsNullOrEmpty(obj.BusinessName))
                exobj.BusinessName = obj.BusinessName;

            if (obj.NetSell != 0)
                exobj.NetSell = obj.NetSell;

            if (obj.NetCost != 0)
                exobj.NetCost = obj.NetCost;

            if (obj.NetProfit != 0)
                exobj.NetProfit = obj.NetProfit;

            if (obj.SellNo != 0)
                exobj.SellNo = obj.SellNo;

            exobj.IsDeleted = false;

            if (obj.CreatedAt != default(DateTime))
                exobj.CreatedAt = obj.CreatedAt;

            if (!string.IsNullOrEmpty(obj.UpdatedBy))
                exobj.UpdatedBy = obj.UpdatedBy;

            if (obj.UpdatedAt != default(DateTime))
                exobj.UpdatedAt = obj.UpdatedAt;

            if (!string.IsNullOrEmpty(obj.DeletedBy))
                exobj.DeletedBy = obj.DeletedBy;

            if (obj.DeletedAt != default(DateTime))
                exobj.DeletedAt = obj.DeletedAt;

            if (obj.Business != null)
                exobj.Business = obj.Business;

            return db.SaveChanges() > 0;
        }
    }
}
