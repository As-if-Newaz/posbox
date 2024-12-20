using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class TransferRepo :Repo, IRepo<Transfer, int, bool>
    {
        public bool Create(Transfer obj)
        {
            db.Transfers.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Transfers.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Transfer> Get()
        {
            return db.Transfers.Where(p => p.IsDeleted == false).ToList();
        }

        public Transfer Get(int id)
        {
            return db.Transfers.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Transfer obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (obj.Product != null)
                exobj.Product = obj.Product;

            if (obj.Quantity != 0)
                exobj.Quantity = obj.Quantity;

            if (obj.TransferTime != default(DateTime))
                exobj.TransferTime = obj.TransferTime;

            if (!string.IsNullOrEmpty(obj.Comment))
                exobj.Comment = obj.Comment;

            if (obj.TransferCost != 0)
                exobj.TransferCost = obj.TransferCost;

            if (!string.IsNullOrEmpty(obj.Status))
                exobj.Status = obj.Status;

            if (obj.FromBusiness != null)
                exobj.FromBusiness = obj.FromBusiness;

            if (obj.ToBusiness != null)
                exobj.ToBusiness = obj.ToBusiness;

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

            return db.SaveChanges() > 0;
        }
    }
}
