using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class BusinessRepo : Repo, IRepo<Business, int, bool>
    {
        public bool Create(Business obj)
        {
            var data = db.Businesses.Where(v => v.Name.Equals(obj.Name)).FirstOrDefault();
            var data1 = db.Businesses.Where(v => v.Phone.Equals(obj.Phone)).FirstOrDefault();
            if (data != null || data1 != null)
                 
            {
                return false;
            }
            db.Businesses.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Businesses.Find(id);
            exobj.IsActive = false;
            return db.SaveChanges() > 0;
        }

        public List<Business> Get()
        {
            return db.Businesses.Where(p => p.IsActive == true).ToList();
        }

        public Business Get(int id)
        {
            return db.Businesses.Where(v => v.Id == id && v.IsActive == true).FirstOrDefault();
        }

        public bool Update(Business obj)
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

            if (!string.IsNullOrEmpty(obj.Phone))
                exobj.Phone = obj.Phone;

            if (!string.IsNullOrEmpty(obj.Email))
                exobj.Email = obj.Email;

            if (!string.IsNullOrEmpty(obj.Role))
                exobj.Role = obj.Role;

                exobj.IsActive = true;

            if (!string.IsNullOrEmpty(obj.Password))
                exobj.Password = obj.Password;

            if(obj.Cash != 0)
                exobj.Cash = obj.Cash;

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

            if (obj.Customers != null)
            {  
                foreach (var customer in obj.Customers)
                {
                    if(exobj.Customers.Contains(customer))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Customers.Add(customer);
                    }
                    
                }
            }

            if (obj.Suppliers != null)
            {
                foreach (var supplier in obj.Suppliers)
                {
                    if (exobj.Suppliers.Contains(supplier))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Suppliers.Add(supplier);
                    }

                }
            }

            if (obj.Invoices != null)
            {
                foreach (var invoice in obj.Invoices)
                {
                    if (exobj.Invoices.Contains(invoice))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Invoices.Add(invoice);
                    }

                }
            }

            if (obj.Products != null)
            {
                foreach (var product in obj.Products)
                {
                    if (exobj.Products.Contains(product))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Products.Add(product);
                    }

                }
            }

            if (obj.Sells != null)
            {
                foreach (var sell in obj.Sells)
                {
                    if (exobj.Sells.Contains(sell))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Sells.Add(sell);
                    }

                }
            }

            if (obj.QuickSells != null)
            {
                foreach (var QuickSell in obj.QuickSells)
                {
                    if (exobj.QuickSells.Contains(QuickSell))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.QuickSells.Add(QuickSell);
                    }

                }
            }

            if (obj.Reports != null)
            {
                foreach (var report in obj.Reports)
                {
                    if (exobj.Reports.Contains(report))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Reports.Add(report);
                    }

                }
            }

            if (obj.Transactions != null)
            {
                foreach (var transaction in obj.Transactions)
                {
                    if (exobj.Transactions.Contains(transaction))
                    {
                        continue;
                    }
                    else
                    {
                        exobj.Transactions.Add(transaction);
                    }

                }
            }

            return db.SaveChanges() > 0;
        }
    }
}
