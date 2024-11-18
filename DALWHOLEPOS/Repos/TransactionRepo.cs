using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class TransactionRepo : Repo, IRepo<Transaction, int, bool>
    {
        public bool Create(Transaction obj)
        {
            db.Transactions.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Transactions.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Transaction> Get()
        {
            return db.Transactions.Where(p => p.IsDeleted == false).ToList();
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Transaction obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.Type))
                exobj.Type = obj.Type;

            if (!string.IsNullOrEmpty(obj.Reason))
                exobj.Reason = obj.Reason;

            if (obj.TransactionTime != default(DateTime))
                exobj.TransactionTime = obj.TransactionTime;

            if (obj.Amount != 0)
                exobj.Amount = obj.Amount;

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
