using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Products.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            return db.Products.Where(p => p.IsDeleted == false).ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Product obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.Name))
                exobj.Name = obj.Name;

            if (obj.Cost != 0)
                exobj.Cost = obj.Cost;

            if (!string.IsNullOrEmpty(obj.CostCode))
                exobj.CostCode = obj.CostCode;

            if (obj.Stock != 0)
                exobj.Stock= obj.Stock;

            if (!string.IsNullOrEmpty(obj.Barcode))
                exobj.Barcode = obj.Barcode;

            if (obj.AddingDate != default(DateTime))
                exobj.AddingDate = obj.AddingDate;

            if (obj.ExpireDate != default(DateTime))
                exobj.ExpireDate = obj.ExpireDate;

            if (!string.IsNullOrEmpty(obj.Comment))
                exobj.Comment = obj.Comment;

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

            if (obj.Supplier != null)
                exobj.Supplier = obj.Supplier;

            return db.SaveChanges() > 0;
        }
    }
}
