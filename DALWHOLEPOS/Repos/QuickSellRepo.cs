using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class QuickSellRepo : Repo, IRepo<QuickSell, int, bool>
    {
        public bool Create(QuickSell obj)
        {
            db.QuickSells.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.QuickSells.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

            public List<QuickSell> Get()
        {
            return db.QuickSells.Where(p => p.IsDeleted == false).ToList();
        }

        public QuickSell Get(int id)
        {
            return db.QuickSells.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(QuickSell obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (obj.Invoice != null)
                exobj.Invoice = obj.Invoice;

            if (!string.IsNullOrEmpty(obj.ProductName))
                exobj.ProductName = obj.ProductName;

            if (obj.Customer != null)
                exobj.Customer = obj.Customer;

            if (obj.Quantity != 0)
                exobj.Quantity = obj.Quantity;

            if (obj.UnitPrice != 0)
                exobj.UnitPrice = obj.UnitPrice;

            exobj.IsDeleted = false;

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

            if (obj.Business != null)
                exobj.Business = obj.Business;

            return db.SaveChanges() > 0;
        }
    }
}
