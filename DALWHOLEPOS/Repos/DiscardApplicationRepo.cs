using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class DiscardApplicationRepo : Repo, IRepo<DiscardApplication, int, bool>
    {
        public bool Create(DiscardApplication obj)
        {
            db.Discards.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Discards.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<DiscardApplication> Get()
        {
            return db.Discards.Where(p => p.IsDeleted == false).ToList();
        }

        public DiscardApplication Get(int id)
        {
            return db.Discards.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(DiscardApplication obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (obj.ProductId != 0)
                exobj.ProductId = obj.ProductId;
           
            if (!string.IsNullOrEmpty(obj.CostCode))
                exobj.CostCode = obj.CostCode;

            if (obj.Quantity != 0)
                exobj.Quantity = obj.Quantity;

            if (obj.NetCost != 0)
                exobj.NetCost = obj.NetCost;

            if (!string.IsNullOrEmpty(obj.Type))
                exobj.Type = obj.Type;

            if (!string.IsNullOrEmpty(obj.Status))
                exobj.Status = obj.Status;

            if (!string.IsNullOrEmpty(obj.CreatedBy))
                exobj.CreatedBy = obj.CreatedBy;

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

            if (obj.BusinessId != 0)
                exobj.BusinessId = obj.BusinessId;


            return db.SaveChanges() > 0;
        }
    }
}
