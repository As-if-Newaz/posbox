using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, bool>
    {
        public bool Create(Customer obj)
        {
            var exists = db.Businesses.Any(v => v.Name == obj.Name || v.Phone == obj.Phone);
            if (exists)
            {
                return false;
            }
            db.Customers.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Customers.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            return db.Customers.Where(p => p.IsDeleted == false).ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Customer obj)
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

            if (obj.Due != 0)
                exobj.Due = obj.Due;

            if (!string.IsNullOrEmpty(obj.Remarks))
                exobj.Remarks = obj.Remarks;

            if (!string.IsNullOrEmpty(obj.Phone))
                exobj.Phone = obj.Phone;

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
