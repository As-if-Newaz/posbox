using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class SupplierRepo : Repo, IRepo<Supplier, int, bool>
    {
        public bool Create(Supplier obj)
        {
            var exists = db.Suppliers.Any(v => v.Name == obj.Name || v.Phone == obj.Phone);
            if (exists)
            {
                return false;
            }
            db.Suppliers.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Suppliers.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Supplier> Get()
        {
            return db.Suppliers.Where(p => p.IsDeleted == false).ToList();
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Supplier obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.Name))
                exobj.Name = obj.Name;

            if (!string.IsNullOrEmpty(obj.Address))
                exobj.Address = obj.Address;

            if (obj.PaymentDue != 0)
                exobj.PaymentDue = obj.PaymentDue;

            if (!string.IsNullOrEmpty(obj.Remarks))
                exobj.Remarks = obj.Remarks;

            if (!string.IsNullOrEmpty(obj.Phone))
                exobj.Phone = obj.Phone;

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
