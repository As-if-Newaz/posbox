using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class InvoiceRepo : Repo, IRepo<Invoice, int, bool>
    {
        public bool Create(Invoice obj)
        {
            
            db.Invoices.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Invoices.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Invoice> Get()
        {
            return db.Invoices.Where(p => p.IsDeleted == false).ToList();
        }

        public Invoice Get(int id)
        {
            return db.Invoices.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public bool Update(Invoice obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (obj.GrossAmount != 0)
                exobj.GrossAmount = obj.GrossAmount;

             if (obj.NetAmount != 0)
                exobj.NetAmount = obj.NetAmount;

              if (obj.DiscountTk != 0)
                exobj.DiscountTk = obj.DiscountTk;

            if (obj.Due != 0)
                exobj.Due = obj.Due;

            if (obj.InvoiceDateTime != default(DateTime))
                exobj.InvoiceDateTime = obj.InvoiceDateTime;

            if (!string.IsNullOrEmpty(obj.PaymentMethod))
                exobj.PaymentMethod = obj.PaymentMethod;

            if (!string.IsNullOrEmpty(obj.Comment))
                exobj.Comment = obj.Comment;

            if (obj.Cost != 0)
                exobj.Cost = obj.Cost;

            if (obj.Profit != 0)
                exobj.Profit = obj.Profit;

            if (!string.IsNullOrEmpty(obj.Status))
                exobj.Status = obj.Status;

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
