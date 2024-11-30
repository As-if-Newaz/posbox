using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class SellRepo : Repo, IRepo<Sell, int, bool>
    {
        public bool Create(Sell obj)
        {
            db.Sells.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Sells.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Sell> Get()
        {
            return db.Sells.Where(p => p.IsDeleted == false).ToList();
        }

        public Sell Get(int id)
        {
            return db.Sells.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Sell obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (obj.Invoice != null)
                exobj.Invoice = obj.Invoice;

            if (obj.Product != null)
                exobj.Product = obj.Product;

            if (obj.Customer != null)
                exobj.Customer = obj.Customer;

            if (obj.Quantity != 0)
                exobj.Quantity = obj.Quantity;

            if (obj.UnitPrice != 0)
                exobj.UnitPrice = obj.UnitPrice;

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
