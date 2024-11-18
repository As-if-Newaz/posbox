using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using DALWHOLEPOS.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS
{
    public class DataAccess
    {
        public IRepo<Business, int, bool> BusinessData ()
            { 
                return new BusinessRepo(); 
            }

        public IRepo<Customer, int, bool> CustomerData()
        {
            return new CustomerRepo();
        }

        public IRepo<Invoice, int, bool> InvoiceData()
        {
            return new InvoiceRepo();
        }

        public IRepo<LoginToken, string, LoginToken> LoginTokenData()
        {
            return new LoginTokenRepo();
        }

        public IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }

        public IRepo<QuickSell, int, bool> QuickSellData()
        {
            return new QuickSellRepo();
        }


        public IRepo<Report, int, bool> ReportData()
        {
            return new ReportRepo();
        }

        public IRepo<Sell, int, bool> SellData()
        {
            return new SellRepo();
        }

        public IRepo<Supplier, int, bool> SupplierData()
        {
            return new SupplierRepo();
        }

        public IRepo<Transaction, int, bool> TransactionData()
        {
            return new TransactionRepo();
        }



    }
}
