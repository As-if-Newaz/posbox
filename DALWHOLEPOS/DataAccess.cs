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
        public static IRepo<Business, int, bool> BusinessData ()
            { 
                return new BusinessRepo(); 
            }

        public static IRepo<Customer, int, bool> CustomerData()
        {
            return new CustomerRepo();
        }

        public static IRepo<Invoice, int, bool> InvoiceData()
        {
            return new InvoiceRepo();
        }

        public static IRepo<LoginToken, string, LoginToken> LoginTokenData()
        {
            return new LoginTokenRepo();
        }

        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<QuickSell, int, bool> QuickSellData()
        {
            return new QuickSellRepo();
        }


        public static IRepo<Report, int, bool> ReportData()
        {
            return new ReportRepo();
        }

        public static IRepo<Sell, int, bool> SellData()
        {
            return new SellRepo();
        }

        public static IRepo<Supplier, int, bool> SupplierData()
        {
            return new SupplierRepo();
        }

        public static IRepo<Transaction, int, bool> TransactionData()
        {
            return new TransactionRepo();
        }

        public static IRepo<DiscardApplication, int, bool> DiscardApplicationData()
        {
            return new DiscardApplicationRepo();
        }



    }
}
